using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetTransporteQueryRuc : QueryBase<GetTransporteDto>
    {
        public GetTransporteQueryRuc(string ruc) => Ruc = ruc;
        public string Ruc { get; set; }
    }
}
