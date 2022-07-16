using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Entity.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using Paltarumi.Acopio.Dto.Base;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class SearchTicketQueryHandler : SearchQueryHandlerBase<SearchTicketQuery, SearchTicketFilterDto, SearchTicketDto>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public SearchTicketQueryHandler(
            IMapper mapper,
            IRepository<Entity.Ticket> ticketRepository
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

            if (filters?.IdLoteBalanza != null)
                filter = filter.And(x => x.IdLoteBalanza == filters.IdLoteBalanza);

            var sorts = new List<SortExpression<Entity.Ticket>>();

            if (request.SearchParams?.Sort != null)
            {
                foreach (var srt in request.SearchParams.Sort)
                {
                    var property = IQueryableExtensions.GetSortExpression<Entity.Ticket>(srt.Direction, srt.Property);
                    if (property != null) sorts.Add(property);
                }
            }

            var tickets = await _ticketRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
                filter,
                x => x.IdConductorNavigation,
                x => x.IdTransporteNavigation,
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
