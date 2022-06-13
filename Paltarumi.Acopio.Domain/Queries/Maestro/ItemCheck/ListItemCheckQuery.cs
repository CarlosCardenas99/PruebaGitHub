using Paltarumi.Acopio.Domain.Dto.Maestro.ItemCheck;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ItemCheck
{
    public class ListItemCheckQuery : QueryBase<IEnumerable<ListItemCheckDto>>
    {
        public ListItemCheckQuery(int idModulo) => IdModulo = idModulo;
        public int IdModulo { get; set; }
    }
}
