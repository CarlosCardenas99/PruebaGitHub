using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Acopio.ItemCheck;

namespace Paltarumi.Acopio.Domain.Queries.Acopio.ItemCheck
{
    public class SearchItemCheckQuery : SearchQueryBase<SearchItemCheckFilterDto, SearchItemCheckDto>
    {
        public SearchItemCheckQuery(SearchParamsDto<SearchItemCheckFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
