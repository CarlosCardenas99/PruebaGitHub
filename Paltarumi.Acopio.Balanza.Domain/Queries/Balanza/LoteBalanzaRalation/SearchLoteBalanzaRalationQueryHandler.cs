using AutoMapper;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using System.Linq.Expressions;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation
{
    public class SearchLoteBalanzaRalationQueryHandler : SearchQueryHandlerBase<SearchLoteBalanzaRalationQuery, SearchLoteBalanzaRalationFilterDto, SearchLoteBalanzaRalationDto>
    {
        private readonly IRepository<Entity.LoteBalanzaRalation> _lotebalanzaralationRepository;

        public SearchLoteBalanzaRalationQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteBalanzaRalation> lotebalanzaralationRepository
        ) : base(mapper)
        {
            _lotebalanzaralationRepository = lotebalanzaralationRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaRalationDto>>> HandleQuery(SearchLoteBalanzaRalationQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchLoteBalanzaRalationDto>>();

            Expression<Func<Entity.LoteBalanzaRalation, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (filters?.IdLoteBalanzaOrigin.HasValue == true)
                filter = filter.And(x => x.IdLoteBalanzaOrigin == filters.IdLoteBalanzaOrigin.Value);

                filter = filter.And(x => x.Activo);

            var lotebalanzaralations = await _lotebalanzaralationRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                null,
                filter,
                x => x.IdLoteBalanzaDestinationNavigation
            );

            var lotebalanzaralationDtos = _mapper?.Map<IEnumerable<SearchLoteBalanzaRalationDto>>(lotebalanzaralations.Items);

            var searchResult = new SearchResultDto<SearchLoteBalanzaRalationDto>(
                lotebalanzaralationDtos ?? new List<SearchLoteBalanzaRalationDto>(),
                lotebalanzaralations.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
