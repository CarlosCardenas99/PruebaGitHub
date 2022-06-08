using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetTransporteQueryRuc : QueryBase<GetTransporteDto>
    {
        public GetTransporteQueryRuc(string ruc) => Ruc = ruc;
        public string Ruc { get; set; }
    }
}
