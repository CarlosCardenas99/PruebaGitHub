using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.CheckList;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.CheckList
{
    public class SearchCheckListQuery : SearchQueryBase<SearchCheckListFilterDto, SearchCheckListDto>
    {
        public SearchCheckListQuery(SearchParamsDto<SearchCheckListFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
