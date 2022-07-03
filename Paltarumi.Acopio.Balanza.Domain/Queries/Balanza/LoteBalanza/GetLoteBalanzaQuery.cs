using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
{
    public class GetLoteBalanzaQuery : QueryBase<GetLoteBalanzaDto>
    {
        public GetLoteBalanzaQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
