using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.CheckList;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.CheckList
{
    public class SearchCheckListQuery : SearchQueryBase<SearchCheckListFilterDto, SearchCheckListDto>
    {
        public SearchCheckListQuery(SearchParamsDto<SearchCheckListFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
