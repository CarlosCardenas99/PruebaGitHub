using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Maestro.Dto.Vehiculo
{
    public class GetVehiculoDto : VehiculoDto
    {
        public int IdVehiculo { get; set; }
        public bool Activo { get; set; }
        public GetMaestroDto? Marca { get; set; }
        public GetMaestroDto? TipoVehiculo { get; set; }
    }
}
