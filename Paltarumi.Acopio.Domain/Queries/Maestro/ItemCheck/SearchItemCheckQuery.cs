using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ItemCheck
{
    public class SearchItemCheckQuery : SearchQueryBase<SearchItemCheckFilterDto, SearchItemCheckDto>
    {
        public SearchItemCheckQuery(SearchParamsDto<SearchItemCheckFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
