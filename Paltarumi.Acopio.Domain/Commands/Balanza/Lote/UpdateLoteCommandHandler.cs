using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Entity.Extensions;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class UpdateLoteCommandHandler : CommandHandlerBase<UpdateLoteCommand, GetLoteDto>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;
        private readonly IRepositoryBase<Entity.Ticket> _ticketRepository;
        private readonly IRepositoryBase<Entity.Vehiculo> _vehiculoRepository;
        private readonly IRepositoryBase<Entity.Transporte> _transporteRepository;
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public UpdateLoteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateLoteCommandValidator validator,
            IRepositoryBase<Entity.Lote> loteRepository,
            IRepositoryBase<Entity.Ticket> ticketRepository,
            IRepositoryBase<Entity.Vehiculo> vehiculoRepository,
            IRepositoryBase<Entity.Transporte> transporteRepository,
            IRepositoryBase<Entity.Conductor> conductorRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _loteRepository = loteRepository;
            _ticketRepository = ticketRepository;
            _vehiculoRepository = vehiculoRepository;
            _transporteRepository = transporteRepository;
            _conductorRepository = conductorRepository;
        }

        public override async Task<ResponseDto<GetLoteDto>> HandleCommand(UpdateLoteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteDto>();

            var lote = await _loteRepository.GetByAsync(x => x.IdLote == request.UpdateDto.IdLote);
            var tickets = await _ticketRepository.FindByAsync(x => x.IdLote == request.UpdateDto.IdLote);
            var ticketDetails = request.UpdateDto?.TicketDetails?.Where(x => x.Activo);

            var idVehiculos = ticketDetails?.Select(x => x.IdVehiculo) ?? new List<int>();
            var vehiculos = await _vehiculoRepository.FindByAsNoTrackingAsync(x => idVehiculos.Contains(x.IdVehiculo));

            var idTransportistas = ticketDetails?.Select(x => x.IdTransporte) ?? new List<int>();
            var transportistas = await _transporteRepository.FindByAsNoTrackingAsync(x => idTransportistas.Contains(x.IdTransporte));

            var idConductores = ticketDetails?.Select(x => x.IdConductor) ?? new List<int>();
            var conductores = await _conductorRepository.FindByAsNoTrackingAsync(x => idConductores.Contains(x.IdConductor));

            if (lote != null)
            {
                _mapper?.Map(request.UpdateDto, lote);

                lote.Tickets = _mapper?.Map<List<Entity.Ticket>>(ticketDetails) ?? new List<Entity.Ticket>();

                lote.UpdateVehiculos(vehiculos);
                lote.UpdateTransportistas(transportistas);
                lote.UpdateConductores(conductores);
                lote.UpdateCantidadSacos();
                lote.UpdateFechaIngreso();
                lote.UpdateHoraIngreso();
                lote.UpdateFechaAcopio();
                lote.UpdateHoraAcopio();
                lote.UpdateTms();
                lote.UpdateTms100();
                lote.UpdateTmsBase();
                lote.UpdateNumeroTickets();

                lote.Tickets = null;

                await _loteRepository.UpdateAsync(lote);

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
                    request.UpdateDto?.TicketDetails?.Where(x => !ticketIds.Contains(x.IdTicket)) ??
                    new List<UpdateTicketDto>();

                var newTickets = _mapper?.Map<IEnumerable<Entity.Ticket>>(newTicketDtos) ??
                    new List<Entity.Ticket>();

                newTickets.ToList().ForEach(t =>
                {
                    t.IdLote = lote.IdLote;
                    t.IdLoteNavigation = null;
                    t.Activo = true;
                });

                await _ticketRepository.AddAsync(newTickets.ToArray());

                #endregion

                var loteDto = _mapper?.Map<GetLoteDto>(lote);
                if (loteDto != null)
                {
                    loteDto.TicketDetails =
                        _mapper?.Map<List<GetTicketDto>>(lote?.Tickets) ?? new List<GetTicketDto>();

                    response.UpdateData(loteDto);
                    response.AddOkResult(Resources.Common.UpdateSuccessMessage);
                }
            }

            return response;
        }
    }
}
