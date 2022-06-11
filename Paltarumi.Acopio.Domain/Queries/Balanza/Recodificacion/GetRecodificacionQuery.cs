using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Recodificacion
{
    public class GetRecodificacionQuery : QueryBase<GetRecodificacionDto>
    {
        public GetRecodificacionQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
