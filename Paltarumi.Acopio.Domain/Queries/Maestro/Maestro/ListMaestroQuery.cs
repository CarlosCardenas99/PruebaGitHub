using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Maestro
{
    public class ListMaestroQuery : QueryBase<IEnumerable<ListMaestroDto>>
    {
        public ListMaestroQuery(string codigoTabla) => CodigoTabla = codigoTabla;
        public string CodigoTabla { get; set; }
    }
}
