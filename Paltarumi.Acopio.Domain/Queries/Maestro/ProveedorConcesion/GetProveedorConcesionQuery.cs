using Paltarumi.Acopio.Domain.Dto.Maestro.ProveedorConcesion;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ProveedorConcesion
{
    public class GetProveedorConcesionQuery : QueryBase<List<GetProveedorConcesionDto>>
    {
        public GetProveedorConcesionQuery(int idProveedor) => IdProveedor = idProveedor;
        public int IdProveedor { get; set; }
    }
}
