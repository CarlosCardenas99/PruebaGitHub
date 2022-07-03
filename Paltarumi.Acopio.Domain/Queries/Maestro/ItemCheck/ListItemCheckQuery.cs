using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.ItemCheck;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ItemCheck
{
    public class ListItemCheckQuery : QueryBase<IEnumerable<ListItemCheckDto>>
    {
        public ListItemCheckQuery(int idModulo) => IdModulo = idModulo;
        public int IdModulo { get; set; }
    }
}
