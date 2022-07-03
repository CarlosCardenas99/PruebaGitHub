using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Conductor
{
    public class SearchConductorQuery : SearchQueryBase<SearchConductorFilterDto, SearchConductorDto>
    {
        public SearchConductorQuery(SearchParamsDto<SearchConductorFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
