using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ProveedorConcesion
{
    public class SearchProveedorConcesionQuery : SearchQueryBase<SearchProveedorConcesionFilterDto, SearchProveedorConcesionDto>
    {
        public SearchProveedorConcesionQuery(SearchParamsDto<SearchProveedorConcesionFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
