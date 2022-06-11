using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.CheckList
{
    public class ListCheckListQuery : QueryBase<IEnumerable<ListCheckListDto>>
    {
        public ListCheckListQuery(int idModulo) => IdModulo = idModulo;
        public int IdModulo { get; set; }
    }
}
