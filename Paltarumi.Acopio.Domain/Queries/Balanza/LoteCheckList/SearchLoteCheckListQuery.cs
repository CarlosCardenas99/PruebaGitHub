using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCheckList
{
    public class SearchLoteCheckListQuery : SearchQueryBase<SearchLoteCheckListFilterDto, SearchLoteCheckListDto>
    {
        public SearchLoteCheckListQuery(SearchParamsDto<SearchLoteCheckListFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
