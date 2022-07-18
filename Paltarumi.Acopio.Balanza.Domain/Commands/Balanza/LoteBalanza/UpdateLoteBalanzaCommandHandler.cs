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

        public UpdateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateLoteBalanzaCommandValidator validator,
            IRepository<Entity.Lote> loteRepository,
            IRepository<Entity.Operacion> operacionRepository,
            IRepository<Entity.LoteOperacion> loteOperacionRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.Ticket> ticketRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteRepository = loteRepository;
            _operacionRepository = operacionRepository;
            _loteOperacionRepository = loteOperacionRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _ticketRepository = ticketRepository;
        }
        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(UpdateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);

            await CreateLoteOperationsAsync(loteBalanza?.CodigoLote!);

            var response = await UpdateLoteBalanza(loteBalanza!, request, cancellationToken);

            await CheckStatusOperacionAsync(loteBalanza?.CodigoLote!, response, request);

            return response;
        }

        private async Task CreateLoteOperationsAsync(string codigoLote)
        {
            var lote = await _loteRepository.GetByAsync(x => x.CodigoLote == codigoLote);
            if (lote == null) return;

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
        }

        public async Task<ResponseDto<GetLoteBalanzaDto>> UpdateLoteBalanza(Entity.LoteBalanza loteBalanza, UpdateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var tickets = await _ticketRepository.FindByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var ticketDetails = request.UpdateDto?.TicketDetails?.Where(x => x.Activo).ToList();

            if (loteBalanza != null && _mediator != null)
            {
                _mapper?.Map(request.UpdateDto, loteBalanza);

                var tickesTmp = loteBalanza.Tickets;

                loteBalanza.Tickets = _mapper?.Map<List<Entity.Ticket>>(ticketDetails) ?? new List<Entity.Ticket>();

                loteBalanza.UpdateCantidadSacos();
                loteBalanza.UpdateFechaIngreso();
                loteBalanza.UpdateFechaAcopio();

                loteBalanza.Tickets = tickesTmp;

                await _loteBalanzaRepository.UpdateAsync(loteBalanza);

                #region Update / Disable Existing

                foreach (var ticket in (tickets ?? new List<Entity.Ticket>()))
                {
                    var ticketDto = request.UpdateDto?.TicketDetails?.FirstOrDefault(x => x.IdTicket == ticket.IdTicket);

                    if (ticketDto != null)
                        _mapper?.Map(ticketDto, ticket);
                    else
                        ticket.Activo = false;

                    await _ticketRepository.UpdateAsync(ticket);
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
                    newTicket.Numero = (await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.TICKET, "1")))?.Data ?? string.Empty;
                    newTicket.IdLoteBalanza = loteBalanza.IdLoteBalanza;
                    newTicket.IdLoteBalanzaNavigation = null!;
                    newTicket.Activo = true;
                };

                await _ticketRepository.AddAsync(newTickets.ToArray());

                #endregion

                var loteDto = _mapper?.Map<GetLoteBalanzaDto>(loteBalanza);
                if (loteDto != null)
                {
                    loteDto.TicketDetails =
                        _mapper?.Map<IEnumerable<ListTicketDto>>(loteBalanza?.Tickets) ?? new List<ListTicketDto>();

                    response.UpdateData(loteDto);
                    response.AddOkResult(Resources.Common.UpdateSuccessMessage);
                }
            }

            return response;
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
    }
}
