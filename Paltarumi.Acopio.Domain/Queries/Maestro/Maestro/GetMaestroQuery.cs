using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Maestro
{
    public class GetMaestroQuery : QueryBase<GetMaestroDto>
    {
        public GetMaestroQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
