using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Maestro
{
    public class ListMaestroQuery : QueryBase<IEnumerable<ListMaestroDto>>
    {
        public ListMaestroQuery(string codigoTabla) => CodigoTabla = codigoTabla;
        public string CodigoTabla { get; set; }
    }
}
