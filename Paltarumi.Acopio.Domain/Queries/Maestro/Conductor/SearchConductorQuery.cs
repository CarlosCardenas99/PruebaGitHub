using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class SearchConductorQuery : SearchQueryBase<SearchConductorFilterDto, SearchConductorDto>
    {
        public SearchConductorQuery(SearchParamsDto<SearchConductorFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
