using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraByDocumentQuery : QueryBase<GetDuenoMuestraDto>
    {
        public GetDuenoMuestraByDocumentQuery(GetDuenoMuestraByDocumentFilterDto filter) => Filter = filter;
        public GetDuenoMuestraByDocumentFilterDto Filter { get; set; }
    }
}
