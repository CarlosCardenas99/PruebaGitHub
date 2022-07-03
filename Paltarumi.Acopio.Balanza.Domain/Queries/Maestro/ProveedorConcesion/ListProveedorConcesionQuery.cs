using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.ProveedorConcesion
{
    public class ListProveedorConcesionQuery : QueryBase<IEnumerable<ListProveedorConcesionDto>>
    {
        public ListProveedorConcesionQuery(int idProveedor) => IdProveedor = idProveedor;
        public int IdProveedor { get; set; }
    }
}
