using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.CheckList;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.CheckList
{
    public class GetCheckListQuery : QueryBase<GetCheckListDto>
    {
        public GetCheckListQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
