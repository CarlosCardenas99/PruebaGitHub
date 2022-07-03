using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.CheckList;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.CheckList
{
    public class GetCheckListQuery : QueryBase<GetCheckListDto>
    {
        public GetCheckListQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
