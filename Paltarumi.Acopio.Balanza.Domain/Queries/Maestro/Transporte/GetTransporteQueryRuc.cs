using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Proveedor
{
    public class GetTransporteQueryRuc : QueryBase<GetTransporteDto>
    {
        public GetTransporteQueryRuc(string ruc) => Ruc = ruc;
        public string Ruc { get; set; }
    }
}
