using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Maestro
{
    public class GetMaestroQuery : QueryBase<GetMaestroDto>
    {
        public GetMaestroQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
