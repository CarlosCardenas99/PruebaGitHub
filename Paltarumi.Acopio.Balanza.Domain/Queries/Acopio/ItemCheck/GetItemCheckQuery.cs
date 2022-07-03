using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.ItemCheck;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.ItemCheck
{
    public class GetItemCheckQuery : QueryBase<GetItemCheckDto>
    {
        public GetItemCheckQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
