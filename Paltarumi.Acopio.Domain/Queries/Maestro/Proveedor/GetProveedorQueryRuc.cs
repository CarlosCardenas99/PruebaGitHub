using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQueryRuc : QueryBase<GetProveedorDto>
    {
        public GetProveedorQueryRuc(string ruc) => Ruc = ruc;
        public string Ruc { get; set; }
    }
}
