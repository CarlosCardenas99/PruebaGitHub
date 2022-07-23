using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class ListTicketQueryHandler : QueryHandlerBase<ListTicketQuery, IEnumerable<ListTicketDto>>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public ListTicketQueryHandler(
            IMapper mapper,
            IRepository<Entity.Ticket> ticketRepository
        ) : base(mapper)
        {
            _ticketRepository = ticketRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListTicketDto>>> HandleQuery(ListTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListTicketDto>>();
            var tickets = await _ticketRepository.FindByAsync(
                x => x.IdLoteBalanza == request.IdLoteBalanza,
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
            var ticketDto = _mapper?.Map<IEnumerable<ListTicketDto>>(tickets);

            if (tickets != null && ticketDto != null)
            {

                response.UpdateData(ticketDto);
            }

            return await Task.FromResult(response);
        }
    }
}
