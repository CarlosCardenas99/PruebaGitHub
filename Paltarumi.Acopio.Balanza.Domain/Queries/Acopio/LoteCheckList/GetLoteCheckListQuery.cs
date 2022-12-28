using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteCheckList
{
    public class GetLoteCheckListQuery : QueryBase<GetLoteCheckListDto>
    {
        public GetLoteCheckListQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
