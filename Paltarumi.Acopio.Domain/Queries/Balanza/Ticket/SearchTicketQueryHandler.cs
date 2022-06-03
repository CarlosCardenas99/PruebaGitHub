using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class SearchTicketQueryHandler: SearchQueryHandlerBase<SearchTicketQuery, TicketFilterDto, SearchTicketDto>
    {
        private readonly IRepositoryBase<Entity.Ticket> _ticketRepository;

        public SearchTicketQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Ticket> ticketRepository
        ) : base(mapper)
        {
            _ticketRepository = ticketRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchTicketDto>>> HandleQuery(SearchTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchTicketDto>>();

            Expression<Func<Entity.Ticket, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.Activo == true)
                filter = filter.And(x => x.Activo == filters.Activo);

            if (filters?.IdLote != null)
                filter = filter.And(x => x.IdLote == filters.IdLote);

            var tickets = await _ticketRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdConductorNavigation,
                x => x.IdTransportistaNavigation,
                x => x.IdUnidadMedidaNavigation,
                x => x.IdVehiculoNavigation,
                x => x.IdVehiculoNavigation.IdVehiculoMarcaNavigation,
                x => x.IdVehiculoNavigation.IdTipoVehiculoNavigation,
                x => x.IdEstadoTmhNavigation
            );

            var ticketDtos = _mapper?.Map<IEnumerable<SearchTicketDto>>(tickets.Items);

            var searchResult = new SearchResultDto<SearchTicketDto>(
                ticketDtos ?? new List<SearchTicketDto>(),
                tickets.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
