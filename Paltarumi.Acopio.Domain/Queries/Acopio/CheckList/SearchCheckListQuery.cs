using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Acopio.CheckList;

namespace Paltarumi.Acopio.Domain.Queries.Acopio.CheckList
{
    public class SearchCheckListQuery : SearchQueryBase<SearchCheckListFilterDto, SearchCheckListDto>
    {
        public SearchCheckListQuery(SearchParamsDto<SearchCheckListFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
