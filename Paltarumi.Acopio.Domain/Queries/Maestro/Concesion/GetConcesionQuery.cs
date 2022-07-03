using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class GetConcesionQuery : QueryBase<GetConcesionDto>
    {
        public GetConcesionQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
