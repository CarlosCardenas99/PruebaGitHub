using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraByDocumentQuery : QueryBase<GetDuenoMuestraDto>
    {
        public GetDuenoMuestraByDocumentQuery(GetDuenoMuestraByDocumentFilterDto filter) => Filter = filter;
        public GetDuenoMuestraByDocumentFilterDto Filter { get; set; }
    }
}
