using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Liquidacion.LoteLiquidacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Dto.Liquidacion;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Entity.Extensions;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCommandHandler : CommandHandlerBase<UpdateLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entity.Correlativo> _correlativoRepository;
        private readonly IRepository<Entity.Lote> _loteRepository;
        private readonly IRepository<Entity.Ticket> _ticketRepository;
        private readonly IRepository<Entity.Operacion> _operacionRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.TicketBackup> _ticketBackupRepository;
        private readonly IRepository<Entity.LoteOperacion> _loteOperacionRepository;

        public UpdateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateLoteBalanzaCommandValidator validator,
            IRepository<Entity.Lote> loteRepository,
            IRepository<Entity.Ticket> ticketRepository,
            IRepository<Entity.Operacion> operacionRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.TicketBackup> ticketBackupRepository,
            IRepository<Entity.LoteOperacion> loteOperacionRepository,
            IRepository<Entity.Correlativo> correlativoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _correlativoRepository = correlativoRepository;
            _loteRepository = loteRepository;
            _ticketRepository = ticketRepository;
            _operacionRepository = operacionRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _ticketBackupRepository = ticketBackupRepository;
            _loteOperacionRepository = loteOperacionRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(UpdateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);

            var lote = await CreateLoteOperations(loteBalanza?.CodigoLote!);

            await CreateBackupTickets(request);

            await UpdateLoteBalanza(request, cancellationToken, response, lote, loteBalanza!);
            if (!response.IsValid) return response;

            await UpdateLoteChancado(cancellationToken, response, response.Data!);
            if (!response.IsValid) return response;

            await UpdateLoteMuestreo(cancellationToken, response, response.Data!);
            if (!response.IsValid) return response;

            await UpdateLoteLiquidacion(cancellationToken, response, response.Data!);
            if (!response.IsValid) return response;

            await CheckStatusOperacion(request, response, loteBalanza?.CodigoLote!);

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
                var backups = _mapper?.Map<IEnumerable<Entity.TicketBackup>>(tickets) ?? new List<Entity.TicketBackup>();

                await _ticketBackupRepository.AddAsync(backups.ToArray());
                await _ticketBackupRepository.SaveAsync();
            }
        }

        private async Task<Entity.Lote> CreateLoteOperations(string codigoLote)
        {
            var lote = await _loteRepository.GetByAsync(x => x.CodigoLote == codigoLote);
            if (lote == null) return null!;

            var operacions = await _operacionRepository.FindByAsNoTrackingAsync(x => x.Codigo.Equals(Constants.Operaciones.Operacion.UPDATE));
            var existingLoteOperacions = await _loteOperacionRepository.FindByAsNoTrackingAsync(x => x.IdLote == lote.IdLote);
            var existingOperacionIds = existingLoteOperacions.Select(x => x.IdOperacion);
            var loteOperacions = new List<Entity.LoteOperacion>();

            foreach (var operacion in operacions.Where(x => !existingOperacionIds.Contains(x.IdOperacion)))
            {
                loteOperacions.Add(new Entity.LoteOperacion
                {
                    IdLote = lote.IdLote,
                    IdOperacionNavigation = null!,
                    IdOperacion = operacion.IdOperacion,
                    Status = Constants.Operaciones.Status.PENDING,
                    Attempts = 0,
                    Body = "",
                    Message = ""
                });
            }

            await _loteOperacionRepository.AddAsync(loteOperacions.ToArray());
            await _loteOperacionRepository.SaveAsync();

            return lote;
        }

        public async Task<ResponseDto<GetLoteBalanzaDto>> UpdateLoteBalanza(UpdateLoteBalanzaCommand request, CancellationToken cancellationToken, ResponseDto<GetLoteBalanzaDto> response, Entity.Lote lote, Entity.LoteBalanza loteBalanza)
        {
            var tickets = await _ticketRepository.FindByAsNoTrackingAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var ticketDetails = request.UpdateDto.TicketDetails?.Where(x => x.Activo).ToList();

            if (loteBalanza != null && _mediator != null)
            {
                _mapper?.Map(request.UpdateDto, loteBalanza);

                var tickesTmp = loteBalanza.Tickets;

                loteBalanza.Tickets = _mapper?.Map<List<Entity.Ticket>>(ticketDetails) ?? new List<Entity.Ticket>();

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

                foreach (var ticket in (tickets ?? new List<Entity.Ticket>()))
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

                var newTickets = _mapper?.Map<IEnumerable<Entity.Ticket>>(newTicketDtos) ??
                    new List<Entity.Ticket>();

                var correlativo = _correlativoRepository.GetByAsNoTrackingAsync(x => x.IdCorrelativo == loteBalanza.IdCorrelativo).Result;

                foreach (var newTicket in newTickets)
                {
                    if (!request.UpdateDto.EsPartido)
                        newTicket.Numero = (await _mediator
                            .Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.TICKET, correlativo.Serie, correlativo.IdEmpresa, correlativo.IdSucursal)))?
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
            var updateResponse = await _mediator?.Send(new UpdateLoteLiquidacionCommand(new UpdateLoteLiquidacionDto
            {
                CodigoLote = loteBalanzaDto.CodigoLote!,
                IdProveedor = loteBalanzaDto.IdProveedor,
                Tmh100 = loteBalanzaDto.Tmh100,
                Tmh = loteBalanzaDto.Tmh,
            }), cancellationToken)!;

            if (updateResponse?.IsValid == false)
                response.AttachResults(updateResponse);
        }

        private async Task CheckStatusOperacion(UpdateLoteBalanzaCommand request, ResponseDto<GetLoteBalanzaDto> response, string codigoLote)
        {
            await _mediator?.Send(new CreateOrUpdateLoteOperacionCommand(new CreateOrUpdateLoteOperacionDto
            {
                CodigoLote = codigoLote,
                Modulo = Constants.Operaciones.Modulo.BALANZA,
                Operacion = Constants.Operaciones.Operacion.UPDATE,
                Body = JsonConvert.SerializeObject(request.UpdateDto),
                Exception = response.IsValid ? null! : new Exception(response.GetFormattedApiResponse())
            }))!;
        }
    }
}
