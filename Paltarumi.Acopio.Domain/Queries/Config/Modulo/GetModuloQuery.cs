using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Config.Modulo;

namespace Paltarumi.Acopio.Domain.Queries.Config.Modulo
{
    public class GetModuloQuery : QueryBase<GetModuloDto>
    {
        public GetModuloQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
