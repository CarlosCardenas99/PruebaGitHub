using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.CheckList;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.CheckList
{
    public class SearchCheckListQuery : SearchQueryBase<SearchCheckListFilterDto, SearchCheckListDto>
    {
        public SearchCheckListQuery(SearchParamsDto<SearchCheckListFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
