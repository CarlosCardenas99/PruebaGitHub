using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.CheckList
{
    public class SearchCheckListQuery : SearchQueryBase<SearchCheckListFilterDto, SearchCheckListDto>
    {
        public SearchCheckListQuery(SearchParamsDto<SearchCheckListFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
