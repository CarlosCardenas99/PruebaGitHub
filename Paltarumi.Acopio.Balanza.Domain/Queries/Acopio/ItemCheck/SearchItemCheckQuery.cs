using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.ItemCheck;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.ItemCheck
{
    public class SearchItemCheckQuery : SearchQueryBase<SearchItemCheckFilterDto, SearchItemCheckDto>
    {
        public SearchItemCheckQuery(SearchParamsDto<SearchItemCheckFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
