using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQuery : QueryBase<GetProveedorDto>
    {
        public GetProveedorQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
