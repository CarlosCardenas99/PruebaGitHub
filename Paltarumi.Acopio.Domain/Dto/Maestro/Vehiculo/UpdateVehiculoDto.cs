namespace Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo
{
    public class UpdateVehiculoDto : VehiculoDto
    {
        public int IdVehiculo { get; set; }
        public bool Activo { get; set; }
    }
}
