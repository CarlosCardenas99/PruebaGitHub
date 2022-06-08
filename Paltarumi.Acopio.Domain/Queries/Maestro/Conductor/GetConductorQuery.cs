using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQuery : QueryBase<GetConductorDto>
    {
        public GetConductorQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
