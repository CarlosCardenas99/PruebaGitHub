using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Proveedor
{
    public class SearchProveedorQuery : SearchQueryBase<SearchProveedorFilterDto, SearchProveedorDto>
    {
        public SearchProveedorQuery(SearchParamsDto<SearchProveedorFilterDto> searchParams) : base(searchParams)
        {

        }
    }
}
