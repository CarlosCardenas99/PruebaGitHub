using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Domain.Extensions;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Liquidacion.Dto.Liquidaciones.LoteLiquidacion;
using Paltarumi.Acopio.Liquidacion.Update.Commands.Liquidaciones.LoteLiquidacion;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCommandHandler : CommandHandlerBase<UpdateLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entities.Correlativo> _correlativoRepository;
        private readonly IRepository<Entities.Ticket> _ticketRepository;
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entities.TicketBackup> _ticketBackupRepository;

        public UpdateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateLoteBalanzaCommandValidator validator,
            IRepository<Entities.Ticket> ticketRepository,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository,
            IRepository<Entities.TicketBackup> ticketBackupRepository,
            IRepository<Entities.Correlativo> correlativoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _correlativoRepository = correlativoRepository;
            _ticketRepository = ticketRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _ticketBackupRepository = ticketBackupRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(UpdateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);

            await CreateBackupTickets(request);

            await UpdateLoteBalanza(request, cancellationToken, response, loteBalanza!);
            if (!response.IsValid) return response;

            await UpdateLoteChancado(cancellationToken, response, response.Data!);
            if (!response.IsValid) return response;

            await UpdateLoteMuestreo(cancellationToken, response, response.Data!);
            if (!response.IsValid) return response;

            await UpdateLoteLiquidacion(cancellationToken, response, response.Data!);
            if (!response.IsValid) return response;

            return response;
        }

        private async Task CreateBackupTickets(UpdateLoteBalanzaCommand request)
        {
            if (!request.UpdateDto.EsPartido)
                return;

            var existingBackups = await _ticketBackupRepository.FindByAsNoTrackingAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            if (existingBackups == null || !existingBackups.Any())
            {
                var tickets = await _ticketRepository.FindByAsNoTrackingAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
                var backups = _mapper?.Map<IEnumerable<Entities.TicketBackup>>(tickets) ?? new List<Entities.TicketBackup>();

                await _ticketBackupRepository.AddAsync(backups.ToArray());
                await _ticketBackupRepository.SaveAsync();
            }
        }

        public async Task<ResponseDto<GetLoteBalanzaDto>> UpdateLoteBalanza(UpdateLoteBalanzaCommand request, CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, Entities.LoteBalanza loteBalanza)
        {
            var tickets = await _ticketRepository.FindByAsNoTrackingAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var ticketDetails = request.UpdateDto.TicketDetails?.Where(x => x.Activo).ToList();

            if (loteBalanza != null && _mediator != null)
            {
                _mapper?.Map(request.UpdateDto, loteBalanza);

                var tickesTmp = loteBalanza.Tickets;

                loteBalanza.Tickets = _mapper?.Map<List<Entities.Ticket>>(ticketDetails) ?? new List<Entities.Ticket>();

                loteBalanza.UpdateCantidadSacos();
                loteBalanza.UpdateFechaIngreso();
                loteBalanza.UpdateFechaAcopio();
                loteBalanza.UpdateTmh();
                loteBalanza.UpdateTmh100();
                loteBalanza.UpdateTmhBase();
                loteBalanza.Tickets = tickesTmp;

                await _loteBalanzaRepository.UpdateAsync(loteBalanza);
                await _loteBalanzaRepository.SaveAsync();

                #region Update / Disable Existing

                foreach (var ticket in (tickets ?? new List<Entities.Ticket>()))
                {
                    var ticketDto = request.UpdateDto.TicketDetails?.FirstOrDefault(x => x.IdTicket == ticket.IdTicket);

                    if (ticketDto != null)
                        _mapper?.Map(ticketDto, ticket);
                    else
                        ticket.Activo = false;

                    await _ticketRepository.UpdateAsync(ticket);
                    await _ticketRepository.SaveAsync();
                }

                #endregion

                #region Add Non Existing

                var ticketIds = tickets?.Select(x => x.IdTicket) ?? new List<int>();

                var newTicketDtos =
                    request.UpdateDto.TicketDetails?.Where(x => !ticketIds.Contains(x.IdTicket)).ToList() ??
                    new List<UpdateTicketDto>();

                var newTickets = _mapper?.Map<IEnumerable<Entities.Ticket>>(newTicketDtos) ??
                    new List<Entities.Ticket>();

                var correlativo = _correlativoRepository.GetByAsNoTrackingAsync(x => x.IdCorrelativo == loteBalanza.IdCorrelativo).Result;

                foreach (var newTicket in newTickets)
                {
                    if (!request.UpdateDto.EsPartido)
                        newTicket.Numero = (await _mediator
                            .Send(new CreateCodeCommand(CONST_ACOPIO.CODIGOCORRELATIVO_TIPO.TICKET, correlativo!.Serie, correlativo.IdEmpresa, correlativo.IdSucursal)))?
                            .Data?.Numero ?? string.Empty;

                    newTicket.IdLoteBalanza = loteBalanza.IdLoteBalanza;
                    newTicket.IdLoteBalanzaNavigation = null!;
                    newTicket.Activo = true;
                };

                await _ticketRepository.AddAsync(newTickets.ToArray());
                await _ticketRepository.SaveAsync();

                #endregion

                var recuprarloteBalanza = await _loteBalanzaRepository.GetByAsNoTrackingAsync(
                    x => x.IdLoteBalanza == loteBalanza.IdLoteBalanza,
                    x => x.Tickets
                );

                var loteDto = _mapper?.Map<GetLoteBalanzaDto>(recuprarloteBalanza);
                if (loteDto != null)
                {
                    var idTickets = loteBalanza.Tickets.Select(x => x.IdTicket);
                    var Nticket = await _ticketRepository.FindByAsNoTrackingAsync(
                        x => idTickets.Contains(x.IdTicket),
                        x => x.IdEstadoTmhNavigation,
                        x => x.IdVehiculoNavigation
                        );

                    loteDto.TicketDetails =
                        _mapper?.Map<IEnumerable<ListTicketDto>>(Nticket.Where(x => x.Activo == true)) ?? new List<ListTicketDto>();

                    response.UpdateData(loteDto);
                    response.AddOkResult(Resources.Common.UpdateSuccessMessage);
                }
            }

            return response;
        }

        private async Task UpdateLoteChancado(CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteBalanzaDto loteBalanzaDto)
        {
            var placas = String.Join(",", loteBalanzaDto.TicketDetails!.Select(x => x.Placa).ToList().Distinct());
            var placasCarretas = String.Join(",", loteBalanzaDto.TicketDetails!.Select(x => x.PlacaCarreta).ToList().Distinct());

            var updateResponse = await _mediator?.Send(new UpdateLoteChancadoCommand(new UpdateLoteChancadoDto
            {
                CodigoLote = loteBalanzaDto.CodigoLote!,
                IdProveedor = loteBalanzaDto.IdProveedor,
                Tmh = loteBalanzaDto.Tmh,
                PlacasTicket = placas,
                PlacasCarretaTicket = placasCarretas,
                ObservacionBalanza = loteBalanzaDto.Observacion!,
                IdLoteEstado = loteBalanzaDto.IdLoteEstado,
            }), cancellationToken)!;

            if (updateResponse?.IsValid == false)
                response.AttachResults(updateResponse);
        }

        private async Task UpdateLoteMuestreo(CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteBalanzaDto loteBalanzaDto)
        {
            var updateResponse = await _mediator?.Send(new UpdateLoteMuestreoCommand(
                new UpdateLoteMuestreoDto
                {
                    FechaAcopio = loteBalanzaDto.FechaAcopio,
                    CodigoLote = loteBalanzaDto.CodigoLote!,
                    IdProveedor = loteBalanzaDto.IdProveedor,
                    Tmh = loteBalanzaDto.Tmh,
                    CodigoAum = loteBalanzaDto.CodigoAum,
                    CodigoTrujillo = loteBalanzaDto.CodigoTrujillo,
                    IdLoteEstado = loteBalanzaDto.IdLoteEstado,
                    ObservacionBalanza = loteBalanzaDto.Observacion
                }), cancellationToken)!;

            if (updateResponse?.IsValid == false)
                response.AttachResults(updateResponse);
        }

        private async Task UpdateLoteLiquidacion(CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, GetLoteBalanzaDto loteBalanzaDto)
        {
            var updateResponse = await _mediator?.Send(new UpdateLoteLiquidacionCommand(new UpdateLoteLiquidacionUpdateDto
            {
                CodigoLote = loteBalanzaDto.CodigoLote!
            }), cancellationToken)!;

            if (updateResponse?.IsValid == false)
                response.AttachResults(updateResponse);
        }

    }
}
