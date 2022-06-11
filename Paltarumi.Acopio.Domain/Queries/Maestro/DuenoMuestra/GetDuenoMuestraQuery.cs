using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraQuery : QueryBase<GetDuenoMuestraDto>
    {
        public GetDuenoMuestraQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
