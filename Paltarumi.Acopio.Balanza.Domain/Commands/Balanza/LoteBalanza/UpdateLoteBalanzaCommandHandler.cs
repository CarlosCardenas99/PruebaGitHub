﻿using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
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
        private readonly IRepository<Entity.Lote> _loteRepository;
        private readonly IRepository<Entity.Operacion> _operacionRepository;
        private readonly IRepository<Entity.LoteOperacion> _loteOperacionRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.Ticket> _ticketRepository;
        private readonly IRepository<Entity.TicketBackup> _backupRepository;

        private readonly IRepository<Entity.LoteMuestreo> _loteMuestreoRepository;
        private readonly IRepository<Entity.LoteChancado> _loteChancadoRepository;
        private readonly IRepository<Entity.Mapa> _mapaRepository;

        public UpdateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateLoteBalanzaCommandValidator validator,
            IRepository<Entity.Lote> loteRepository,
            IRepository<Entity.Operacion> operacionRepository,
            IRepository<Entity.LoteOperacion> loteOperacionRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.Ticket> ticketRepository,
            IRepository<Entity.TicketBackup> backupRepository,

            IRepository<Entity.LoteMuestreo> loteMuestreoRepository,
            IRepository<Entity.LoteChancado> loteChancadoRepository,
            IRepository<Entity.Mapa> mapaRepository

        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteRepository = loteRepository;
            _operacionRepository = operacionRepository;
            _loteOperacionRepository = loteOperacionRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _ticketRepository = ticketRepository;
            _backupRepository = backupRepository;

            _loteMuestreoRepository = loteMuestreoRepository;
            _loteChancadoRepository = loteChancadoRepository;
            _mapaRepository = mapaRepository;
        }
        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(UpdateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            await registrarBackupTicket(request);

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);

            var lote = await CreateLoteOperationsAsync(loteBalanza?.CodigoLote!);

            var response = await UpdateLoteBalanza(lote, loteBalanza!, request, cancellationToken);

            await UpdateLoteChancadoAsync(response);

            var loteMuestreoRegistrado = await UpdateLoteMuestreoAsync(response);

            await CheckStatusOperacionAsync(loteBalanza?.CodigoLote!, response, request);

            return response;
        }

        private async Task<Entity.Lote> CreateLoteOperationsAsync(string codigoLote)
        {
            var lote = await _loteRepository.GetByAsync(x => x.CodigoLote == codigoLote);
            if (lote == null) return null;

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

        public async Task<ResponseDto<GetLoteBalanzaDto>> UpdateLoteBalanza(Entity.Lote lote, Entity.LoteBalanza loteBalanza, UpdateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var tickets = await _ticketRepository.FindByAsNoTrackingAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var ticketDetails = request.UpdateDto?.TicketDetails?.Where(x => x.Activo).ToList();

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
                    var ticketDto = request.UpdateDto?.TicketDetails?.FirstOrDefault(x => x.IdTicket == ticket.IdTicket);

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
                    request.UpdateDto?.TicketDetails?.Where(x => !ticketIds.Contains(x.IdTicket)).ToList() ??
                    new List<UpdateTicketDto>();

                var newTickets = _mapper?.Map<IEnumerable<Entity.Ticket>>(newTicketDtos) ??
                    new List<Entity.Ticket>();

                foreach (var newTicket in newTickets)
                {
                    if (!request.UpdateDto.EsPartido)
                        newTicket.Numero = (await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.TICKET, "1", lote.IdEmpresa)))?.Data ?? string.Empty;

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
                    loteDto.TicketDetails =
                        _mapper?.Map<IEnumerable<ListTicketDto>>(recuprarloteBalanza?.Tickets.Where(x => x.Activo == true)) ?? new List<ListTicketDto>();

                    response.UpdateData(loteDto);
                    response.AddOkResult(Resources.Common.UpdateSuccessMessage);
                }
            }

            return response;
        }

        private async Task UpdateLoteChancadoAsync(ResponseDto<GetLoteBalanzaDto> response)
        {
            var loteChancado = await _loteChancadoRepository.GetByAsync(x => x.CodigoLote == response.Data!.CodigoLote);

            var ticket = await _ticketRepository.GetByAsync(
                   x => x.IdLoteBalanza == response.Data!.IdLoteBalanza,
                   x => x.IdVehiculoNavigation
                );

            if (loteChancado != null)
            {
                loteChancado.IdProveedor = response.Data!.IdProveedor;
                loteChancado.Placa = ticket!.IdVehiculoNavigation != null ? ticket.IdVehiculoNavigation.Placa : string.Empty;
                loteChancado.PlacaCarreta = ticket.IdVehiculoNavigation != null ? ticket.IdVehiculoNavigation.PlacaCarreta : string.Empty;
                loteChancado.UpdateDate = DateTimeOffset.Now;
                loteChancado.UserNameUpdate = string.Empty;

                await _loteChancadoRepository.UpdateAsync(loteChancado);
                await _loteChancadoRepository.SaveAsync();
            }
        }

        private async Task<ResponseDto<GetLoteMuestreoDto>> UpdateLoteMuestreoAsync(ResponseDto<GetLoteBalanzaDto> response)
        {
            var loteMuestreoRegistrado = new ResponseDto<GetLoteMuestreoDto>();

            var lotemuestreo = await _loteMuestreoRepository.GetByAsync(x => x.CodigoLote == response.Data!.CodigoLote);

            if (lotemuestreo != null)
            {
                lotemuestreo.IdProveedor = response.Data.IdProveedor;
                lotemuestreo.Tmh = response.Data.Tmh;
                lotemuestreo.CodigoAum = response.Data.CodigoAum;
                lotemuestreo.CodigoTrujillo = response.Data.CodigoTrujillo;
                lotemuestreo.UpdateDate = DateTimeOffset.Now;
                lotemuestreo.UserNameUpdate = string.Empty;

                await _loteMuestreoRepository.UpdateAsync(lotemuestreo);
                await _loteMuestreoRepository.SaveAsync();

                var loteMuestreo = _mapper?.Map<GetLoteMuestreoDto>(lotemuestreo);

                loteMuestreoRegistrado.UpdateData(loteMuestreo);
            }
            return loteMuestreoRegistrado;
        }

        private async Task CheckStatusOperacionAsync(string codigoLote, ResponseDto<GetLoteBalanzaDto> response, UpdateLoteBalanzaCommand request)
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

        private async Task registrarBackupTicket(UpdateLoteBalanzaCommand request)
        {
            if (request.UpdateDto.EsPartido)
            {
                var exsteBackup = await _backupRepository.FindByAsNoTrackingAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
                if (exsteBackup == null || exsteBackup.ToList().Count == 0)
                {
                    var tickets = await _ticketRepository.FindByAsNoTrackingAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
                    var backups = _mapper?.Map<IEnumerable<Entity.TicketBackup>>(tickets);

                    await _backupRepository.AddAsync(backups.ToArray());
                    await _backupRepository.SaveAsync();
                }
            }

        }
    }
}
