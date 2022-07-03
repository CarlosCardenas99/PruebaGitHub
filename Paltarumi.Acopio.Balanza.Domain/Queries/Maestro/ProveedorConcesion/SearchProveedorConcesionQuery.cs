using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.ProveedorConcesion
{
    public class SearchProveedorConcesionQuery : SearchQueryBase<SearchProveedorConcesionFilterDto, SearchProveedorConcesionDto>
    {
        public SearchProveedorConcesionQuery(SearchParamsDto<SearchProveedorConcesionFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
