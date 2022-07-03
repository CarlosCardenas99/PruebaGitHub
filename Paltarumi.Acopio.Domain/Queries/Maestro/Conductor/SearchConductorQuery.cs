using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class SearchConductorQuery : SearchQueryBase<SearchConductorFilterDto, SearchConductorDto>
    {
        public SearchConductorQuery(SearchParamsDto<SearchConductorFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
