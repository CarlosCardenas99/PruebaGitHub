using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Conductor
{
    public class GetConductorByDocumentQuery : QueryBase<GetConductorDto>
    {
        public GetConductorByDocumentQuery(GetConductorByDocumentFilterDto filter) => Filter = filter;
        public GetConductorByDocumentFilterDto Filter { get; set; }
    }
}
