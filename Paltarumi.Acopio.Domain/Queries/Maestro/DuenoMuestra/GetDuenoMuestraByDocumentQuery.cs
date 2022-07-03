using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.DuenoMuestra;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraByDocumentQuery : QueryBase<GetDuenoMuestraDto>
    {
        public GetDuenoMuestraByDocumentQuery(GetDuenoMuestraByDocumentFilterDto filter) => Filter = filter;
        public GetDuenoMuestraByDocumentFilterDto Filter { get; set; }
    }
}
