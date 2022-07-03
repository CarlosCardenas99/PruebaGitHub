using Paltarumi.Acopio.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Dto.Maestro.Vehiculo
{
    public class GetVehiculoDto : VehiculoDto
    {
        public int IdVehiculo { get; set; }
        public bool Activo { get; set; }
        public GetMaestroDto? Marca { get; set; }
        public GetMaestroDto? TipoVehiculo { get; set; }
    }
}
