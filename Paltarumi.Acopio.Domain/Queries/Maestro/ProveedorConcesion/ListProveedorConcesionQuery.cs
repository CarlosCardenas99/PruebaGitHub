using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ProveedorConcesion
{
    public class ListProveedorConcesionQuery : QueryBase<IEnumerable<ListProveedorConcesionDto>>
    {
        public ListProveedorConcesionQuery(int idProveedor) => IdProveedor = idProveedor;
        public int IdProveedor { get; set; }
    }
}
