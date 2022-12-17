using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteCheckList
{
    public class ListLoteCheckListQuery : QueryBase<IEnumerable<ListLoteCheckListDto>>
    {
        public ListLoteCheckListQuery(int idLoteBalanza) => IdLoteBalanza = idLoteBalanza;
        public int IdLoteBalanza { get; set; }
    }
}
