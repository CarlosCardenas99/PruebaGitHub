using Paltarumi.Acopio.Domain.Dto.Balanza.CheckList;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.CheckList
{
    public class GetCheckListQuery : QueryBase<GetCheckListDto>
    {
        public GetCheckListQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
