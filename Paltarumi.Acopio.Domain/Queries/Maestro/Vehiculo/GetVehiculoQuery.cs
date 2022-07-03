using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoQuery : QueryBase<GetVehiculoDto>
    {
        public GetVehiculoQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
