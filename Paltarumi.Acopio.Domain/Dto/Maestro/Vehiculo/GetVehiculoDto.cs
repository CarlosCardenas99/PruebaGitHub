using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo
{
    public class GetVehiculoDto : VehiculoDto
    {
        public int IdVehiculo { get; set; }
        public bool Activo { get; set; }
        public GetMaestroDto? Marca { get; set; }
        public GetMaestroDto? TipoVehiculo { get; set; }
    }
}
