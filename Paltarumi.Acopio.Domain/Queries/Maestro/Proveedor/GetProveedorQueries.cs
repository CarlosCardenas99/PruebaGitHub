using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQuery : QueryBase<GetProveedorDto>
    {
        public GetProveedorQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
