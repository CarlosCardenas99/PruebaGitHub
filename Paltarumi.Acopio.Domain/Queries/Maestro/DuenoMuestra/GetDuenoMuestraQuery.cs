using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.DuenoMuestra;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraQuery : QueryBase<GetDuenoMuestraDto>
    {
        public GetDuenoMuestraQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
