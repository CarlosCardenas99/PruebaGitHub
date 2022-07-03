using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Concesion
{
    public class ListConcesionQuery : QueryBase<IEnumerable<ListConcesionDto>>
    {
        public ListConcesionQuery(ListConcesionFilterDto filter) => Filter = filter;
        public ListConcesionFilterDto Filter { get; set; }
    }
}
