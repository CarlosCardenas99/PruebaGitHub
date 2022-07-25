using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class ListItemTicketQueryHandler : QueryHandlerBase<ListItemTicketQuery, ListTicketDto>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public ListItemTicketQueryHandler(
            IMapper mapper,
            IRepository<Entity.Ticket> ticketRepository
        ) : base(mapper)
        {
            _ticketRepository = ticketRepository;
        }

        protected override async Task<ResponseDto<ListTicketDto>> HandleQuery(ListItemTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<ListTicketDto>();
            var ticket = await _ticketRepository.GetByAsNoTrackingAsync(
                x => x.IdTicket == request.IdTicket,
                x => x.IdConductorNavigation,
                x => x.IdConductorNavigation.IdTipoLicenciaNavigation,
                x => x.IdTransporteNavigation,
                x => x.IdEstadoTmhNavigation,
                x => x.IdEstadoTmhCarretaNavigation,
                x => x.IdUnidadMedidaNavigation,
                x => x.IdVehiculoNavigation,
                x => x.IdVehiculoNavigation.IdTipoVehiculoNavigation,
                x => x.IdVehiculoNavigation.IdVehiculoMarcaNavigation
                );
            var ticketDto = _mapper?.Map<ListTicketDto>(ticket) ?? new ListTicketDto();

            if (ticket != null && ticketDto != null)
            {

                response.UpdateData(ticketDto);
            }

            return await Task.FromResult(response);
        }
    }
}
