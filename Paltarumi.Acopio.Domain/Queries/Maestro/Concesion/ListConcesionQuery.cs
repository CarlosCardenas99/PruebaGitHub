using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class ListConcesionQuery : QueryBase<IEnumerable<ListConcesionDto>>
    {
        public ListConcesionQuery(ListConcesionFilterDto filter) => Filter = filter;
        public ListConcesionFilterDto Filter { get; set; }
    }
}
