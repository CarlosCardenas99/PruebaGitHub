using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorByDocumentQuery : QueryBase<GetConductorDto>
    {
        public GetConductorByDocumentQuery(GetConductorByDocumentFilterDto filter) => Filter = filter;
        public GetConductorByDocumentFilterDto Filter { get; set; }
    }
}
