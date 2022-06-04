using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ProveedorConcesion
{
    public class SearchProveedorConcesionQuery : SearchQueryBase<ProveedorConcesionFilterDto, SearchProveedorConcesionDto>
    {
        public SearchProveedorConcesionQuery(SearchParamsDto<ProveedorConcesionFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
