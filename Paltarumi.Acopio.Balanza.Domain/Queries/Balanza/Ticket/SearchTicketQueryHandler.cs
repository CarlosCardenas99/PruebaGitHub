using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Entity.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Extensions;
using System.Linq.Expressions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class SearchTicketQueryHandler : SearchQueryHandlerBase<SearchTicketQuery, SearchTicketFilterDto, SearchTicketDto>
    {
        private readonly IRepository<Entities.Ticket> _ticketRepository;

        public SearchTicketQueryHandler(
            IMapper mapper,
            IRepository<Entities.Ticket> ticketRepository
        ) : base(mapper)
        {
            _ticketRepository = ticketRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchTicketDto>>> HandleQuery(SearchTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchTicketDto>>();

            Expression<Func<Entities.Ticket, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.Activo == true)
                filter = filter.And(x => x.Activo == filters.Activo);

            if (filters?.IdLoteBalanza != null)
                filter = filter.And(x => x.IdLoteBalanza == filters.IdLoteBalanza);

            var sorts = new List<SortExpression<Entities.Ticket>>();

            if (request.SearchParams?.Sort != null)
            {
                foreach (var srt in request.SearchParams.Sort)
                {
                    var property = IQueryableExtensions.GetSortExpression<Entities.Ticket>(srt.Direction, srt.Property);
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
