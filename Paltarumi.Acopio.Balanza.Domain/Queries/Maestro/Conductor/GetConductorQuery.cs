using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQuery : QueryBase<GetConductorDto>
    {
        public GetConductorQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
