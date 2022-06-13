using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.LoteBalanza
{
    public class GetLoteBalanzaQuery : QueryBase<GetLoteBalanzaDto>
    {
        public GetLoteBalanzaQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
