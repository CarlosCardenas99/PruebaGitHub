using Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ItemCheck
{
    public class GetItemCheckQuery : QueryBase<GetItemCheckDto>
    {
        public GetItemCheckQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
