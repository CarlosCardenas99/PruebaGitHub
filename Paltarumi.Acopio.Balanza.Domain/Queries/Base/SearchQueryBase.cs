using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Base
{
    public class SearchQueryBase<TFilter, TResponse> : QueryBase<SearchResultDto<TResponse>>
    {
        public SearchQueryBase(SearchParamsDto<TFilter> searchParams) => SearchParams = searchParams;
        public SearchParamsDto<TFilter> SearchParams { get; set; }
    }
}
