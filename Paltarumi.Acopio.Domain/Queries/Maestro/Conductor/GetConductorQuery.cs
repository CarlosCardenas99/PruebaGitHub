using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQuery : QueryBase<GetConductorDto>
    {
        public GetConductorQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
