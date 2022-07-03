using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorByDocumentQuery : QueryBase<GetConductorDto>
    {
        public GetConductorByDocumentQuery(GetConductorByDocumentFilterDto filter) => Filter = filter;
        public GetConductorByDocumentFilterDto Filter { get; set; }
    }
}
