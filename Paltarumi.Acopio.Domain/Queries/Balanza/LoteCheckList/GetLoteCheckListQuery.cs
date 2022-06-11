using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCheckList
{
    public class GetLoteCheckListQuery : QueryBase<GetLoteCheckListDto>
    {
        public GetLoteCheckListQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
