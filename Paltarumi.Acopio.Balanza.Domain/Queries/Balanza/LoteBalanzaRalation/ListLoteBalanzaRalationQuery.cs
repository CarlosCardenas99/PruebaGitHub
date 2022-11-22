using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation
{
    public class ListLoteBalanzaRalationQuery : QueryBase<IEnumerable<ListLoteBalanzaRalationDto>>
    {
        public ListLoteBalanzaRalationQuery(int idLoteBalanza) => IdLoteBalanza = idLoteBalanza;
        public int IdLoteBalanza { get; set; }
    }
}
