using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQueryRuc : QueryBase<GetProveedorDto>
    {
        public GetProveedorQueryRuc(string ruc) => Ruc = ruc;
        public string Ruc { get; set; }
    }
}
