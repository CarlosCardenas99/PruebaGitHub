using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class SearchProveedorQuery : SearchQueryBase<ProveedorFilterDto, SearchProveedorDto>
    {
        public SearchProveedorQuery(SearchParamsDto<ProveedorFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
