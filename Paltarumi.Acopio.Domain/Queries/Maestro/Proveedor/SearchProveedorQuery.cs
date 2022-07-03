using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class SearchProveedorQuery : SearchQueryBase<SearchProveedorFilterDto, SearchProveedorDto>
    {
        public SearchProveedorQuery(SearchParamsDto<SearchProveedorFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
