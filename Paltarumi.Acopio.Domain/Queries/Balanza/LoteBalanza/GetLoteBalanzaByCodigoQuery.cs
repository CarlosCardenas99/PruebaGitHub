using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteBalanza;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteBalanza
{
    public class GetLoteBalanzaByCodigoQuery : QueryBase<GetLoteBalanzaCodigoDto>
    {
        public GetLoteBalanzaByCodigoQuery(string codigo) => Codigo = codigo;
        public string? Codigo { get; set; }
    }
}
