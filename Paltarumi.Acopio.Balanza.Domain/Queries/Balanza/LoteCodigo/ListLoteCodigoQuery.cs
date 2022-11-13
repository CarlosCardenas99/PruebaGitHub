using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo
{
    public class ListLoteCodigoQuery : QueryBase<IEnumerable<ListLoteCodigoDto>>
    {
        public ListLoteCodigoQuery(string codigoLote) => CodigoLote = codigoLote;
        public string CodigoLote { get; set; }
    }
}
