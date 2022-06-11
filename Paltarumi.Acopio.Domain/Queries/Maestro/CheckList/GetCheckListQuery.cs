using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.CheckList
{
    public class GetCheckListQuery : QueryBase<GetCheckListDto>
    {
        public GetCheckListQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
