using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Config.Dto.Modulo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Config.Modulo
{
    public class GetModuloQuery : QueryBase<GetModuloDto>
    {
        public GetModuloQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
