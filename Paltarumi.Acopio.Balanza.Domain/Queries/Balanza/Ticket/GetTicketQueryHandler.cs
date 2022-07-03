using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Ticket;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;
using Paltarumi.Acopio.Maestro.Dto.Maestro;
using Paltarumi.Acopio.Maestro.Dto.Transporte;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class GetTicketQueryHandler : QueryHandlerBase<GetTicketQuery, GetTicketDto>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public GetTicketQueryHandler(
            IMapper mapper,
            GetTicketQueryValidator validator,
            IRepository<Entity.Ticket> ticketRepository
        ) : base(mapper, validator)
        {
            _ticketRepository = ticketRepository;
        }

        protected override async Task<ResponseDto<GetTicketDto>> HandleQuery(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTicketDto>();
            var ticket = await _ticketRepository.GetByAsync(
                x => x.IdTicket == request.Id,
                x => x.IdConductorNavigation,
                x => x.IdTransporteNavigation,
                x => x.IdEstadoTmhNavigation,
                x => x.IdUnidadMedidaNavigation,
                x => x.IdVehiculoNavigation,
                x => x.IdVehiculoNavigation.IdTipoVehiculoNavigation,
                x => x.IdVehiculoNavigation.IdVehiculoMarcaNavigation
                );
            var ticketDto = _mapper?.Map<GetTicketDto>(ticket);

            if (ticket != null && ticketDto != null)
            {
                ticketDto.Conductor = _mapper?.Map<GetConductorDto>(ticket.IdConductorNavigation);
                ticketDto.Transporte = _mapper?.Map<GetTransporteDto>(ticket.IdTransporteNavigation);
                ticketDto.EstadoTmh = _mapper?.Map<GetMaestroDto>(ticket.IdEstadoTmhNavigation);
                ticketDto.UnidadMedida = _mapper?.Map<GetMaestroDto>(ticket.IdUnidadMedidaNavigation);
                ticketDto.Vehiculo = _mapper?.Map<GetVehiculoDto>(ticket.IdVehiculoNavigation);
                if (ticketDto.Vehiculo != null) ticketDto.Vehiculo.Marca = ticket.IdVehiculoNavigation == null ? null : _mapper?.Map<GetMaestroDto>(ticket.IdVehiculoNavigation.IdVehiculoMarcaNavigation);
                if (ticketDto.Vehiculo != null) ticketDto.Vehiculo.TipoVehiculo = ticket.IdVehiculoNavigation == null ? null : _mapper?.Map<GetMaestroDto>(ticket.IdVehiculoNavigation.IdTipoVehiculoNavigation);
                response.UpdateData(ticketDto);
            }

            return await Task.FromResult(response);
        }
    }
}
