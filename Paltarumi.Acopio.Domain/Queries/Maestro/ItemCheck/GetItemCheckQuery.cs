using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.ItemCheck;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ItemCheck
{
    public class GetItemCheckQuery : QueryBase<GetItemCheckDto>
    {
        public GetItemCheckQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
