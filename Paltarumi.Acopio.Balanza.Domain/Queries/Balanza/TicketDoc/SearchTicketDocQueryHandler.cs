using AutoMapper;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.TicketDoc
{
    public class SearchTicketDocQueryHandler : SearchQueryHandlerBase<SearchTicketDocQuery, SearchTicketDocFilterDto, SearchTicketDocDto>
    {
        private readonly IRepository<Entity.TicketDoc> _ticketdocRepository;

        public SearchTicketDocQueryHandler(
            IMapper mapper,
            IRepository<Entity.TicketDoc> ticketdocRepository
        ) : base(mapper)
        {
            _ticketdocRepository = ticketdocRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchTicketDocDto>>> HandleQuery(SearchTicketDocQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchTicketDocDto>>();

            Expression<Func<Entity.TicketDoc, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdTicketDoc.HasValue == true)
                filter = filter.And(x => x.IdTicketDoc == filters.IdTicketDoc.Value);

            if (filters?.Activo.HasValue == true)
                filter = filter.And(x => x.Activo == filters.Activo.Value);

            var ticketdocs = await _ticketdocRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter
            );

            var ticketdocDtos = _mapper?.Map<IEnumerable<SearchTicketDocDto>>(ticketdocs.Items);

            var searchResult = new SearchResultDto<SearchTicketDocDto>(
                ticketdocDtos ?? new List<SearchTicketDocDto>(),
                ticketdocs.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
