using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class GetConcesionQuery : QueryBase<GetConcesionDto>
    {
        public GetConcesionQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
