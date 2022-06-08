using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Maestro
{
    public class GetMaestroQuery : QueryBase<GetMaestroDto>
    {
        public GetMaestroQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
