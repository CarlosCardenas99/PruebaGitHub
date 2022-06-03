using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQueryRuc : QueryBase<GetProveedorDto>
    {
        public GetProveedorQueryRuc(string ruc) => Ruc = ruc;
        public string Ruc { get; set; }
    }
}
