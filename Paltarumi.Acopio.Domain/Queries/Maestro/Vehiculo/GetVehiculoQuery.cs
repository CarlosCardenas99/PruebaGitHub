using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoQuery : QueryBase<GetVehiculoDto>
    {
        public GetVehiculoQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
