using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Acopio.CheckList;

namespace Paltarumi.Acopio.Domain.Queries.Acopio.CheckList
{
    public class GetCheckListQuery : QueryBase<GetCheckListDto>
    {
        public GetCheckListQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
