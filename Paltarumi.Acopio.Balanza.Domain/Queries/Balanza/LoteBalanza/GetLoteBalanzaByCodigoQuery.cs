using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanza
{
    public class GetLoteBalanzaByCodigoQuery : QueryBase<GetLoteBalanzaCodigoDto>
    {
        public GetLoteBalanzaByCodigoQuery(string codigoLote) => CodigoLote = codigoLote;
        public string? CodigoLote { get; set; }
    }
}
