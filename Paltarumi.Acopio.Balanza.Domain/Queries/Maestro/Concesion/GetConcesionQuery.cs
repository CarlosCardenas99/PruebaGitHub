using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Concesion
{
    public class GetConcesionQuery : QueryBase<GetConcesionDto>
    {
        public GetConcesionQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
