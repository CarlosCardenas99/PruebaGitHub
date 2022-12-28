using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteCheckList
{
    public class ListLoteCheckListQuery : QueryBase<IEnumerable<ListLoteCheckListDto>>
    {
        public ListLoteCheckListQuery(int idLoteBalanza, string modulo)
        {
            IdLoteBalanza = idLoteBalanza;
            Modulo = modulo;
        }

        public int IdLoteBalanza { get; set; }
        public string Modulo { get; set; }
    }
}
