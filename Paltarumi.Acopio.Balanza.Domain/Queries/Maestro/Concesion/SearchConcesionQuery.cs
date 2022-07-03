using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Concesion
{
    public class SearchConcesionQuery : SearchQueryBase<SearchConcesionFilterDto, SearchConcesionDto>
    {
        public SearchConcesionQuery(SearchParamsDto<SearchConcesionFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
