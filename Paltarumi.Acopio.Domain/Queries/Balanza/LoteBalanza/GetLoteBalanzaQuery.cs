using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteBalanza;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.LoteBalanza
{
    public class GetLoteBalanzaQuery : QueryBase<GetLoteBalanzaDto>
    {
        public GetLoteBalanzaQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
