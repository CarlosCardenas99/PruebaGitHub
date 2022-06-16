using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Commands.Common;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Entity.Extensions;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCommandHandler : CommandHandlerBase<UpdateLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.Ticket> _ticketRepository;
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;
        private readonly IRepository<Entity.Transporte> _transporteRepository;
        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public UpdateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateLoteBalanzaCommandValidator validator,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.Ticket> ticketRepository,
            IRepository<Entity.Vehiculo> vehiculoRepository,
            IRepository<Entity.Transporte> transporteRepository,
            IRepository<Entity.Conductor> conductorRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
            _ticketRepository = ticketRepository;
            _vehiculoRepository = vehiculoRepository;
            _transporteRepository = transporteRepository;
            _conductorRepository = conductorRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(UpdateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var tickets = await _ticketRepository.FindByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var ticketDetails = request.UpdateDto?.TicketDetails?.Where(x => x.Activo).ToList();

            var idVehiculos = ticketDetails?.Select(x => x.IdVehiculo) ?? new List<int>();
            var vehiculos = await _vehiculoRepository.FindByAsNoTrackingAsync(x => idVehiculos.Contains(x.IdVehiculo));

            var idTransportistas = ticketDetails?.Select(x => x.IdTransporte) ?? new List<int>();
            var transportistas = await _transporteRepository.FindByAsNoTrackingAsync(x => idTransportistas.Contains(x.IdTransporte));

            var idConductores = ticketDetails?.Select(x => x.IdConductor) ?? new List<int>();
            var conductores = await _conductorRepository.FindByAsNoTrackingAsync(x => idConductores.Contains(x.IdConductor));

            if (loteBalanza != null)
            {
                _mapper?.Map(request.UpdateDto, loteBalanza);

                var tickesTmp = loteBalanza.Tickets;

                loteBalanza.Tickets = _mapper?.Map<List<Entity.Ticket>>(ticketDetails) ?? new List<Entity.Ticket>();

                loteBalanza.UpdateVehiculos(vehiculos);
                loteBalanza.UpdateTransportistas(transportistas);
                loteBalanza.UpdateConductores(conductores);
                loteBalanza.UpdateCantidadSacos();
                loteBalanza.UpdateFechaIngreso();
                loteBalanza.UpdateHoraIngreso();
                loteBalanza.UpdateFechaAcopio();
                loteBalanza.UpdateHoraAcopio();
                loteBalanza.UpdateTms();
                loteBalanza.UpdateTms100();
                loteBalanza.UpdateTmsBase();
                loteBalanza.UpdateNumeroTickets();

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
                    newTicket.IdLoteBalanzaNavigation = null;
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
    }
}
