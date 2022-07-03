using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoQuery : QueryBase<GetVehiculoDto>
    {
        public GetVehiculoQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
