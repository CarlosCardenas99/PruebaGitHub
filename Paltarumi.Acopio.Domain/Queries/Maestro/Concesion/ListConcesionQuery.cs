using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class ListConcesionQuery : QueryBase<IEnumerable<ListConcesionDto>>
    {
        public ListConcesionQuery(ListConcesionFilterDto filter) => Filter = filter;
        public ListConcesionFilterDto Filter { get; set; }
    }
}
