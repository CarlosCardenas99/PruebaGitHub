using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Maestro
{
    public class GetMaestroQuery : QueryBase<GetMaestroDto>
    {
        public GetMaestroQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
