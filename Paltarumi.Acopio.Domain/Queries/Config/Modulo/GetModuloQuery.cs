using Paltarumi.Acopio.Domain.Dto.Config.Modulo;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Config.Modulo
{
    public class GetModuloQuery : QueryBase<GetModuloDto>
    {
        public GetModuloQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
