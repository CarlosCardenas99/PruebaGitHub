using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation
{
    public class GetLoteBalanzaRalationQuery : QueryBase<GetLoteBalanzaRalationDto>
    {
        public GetLoteBalanzaRalationQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
