using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraQuery : QueryBase<GetDuenoMuestraDto>
    {
        public GetDuenoMuestraQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
