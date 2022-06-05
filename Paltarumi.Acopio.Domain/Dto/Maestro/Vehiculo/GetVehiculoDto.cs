namespace Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo
{
    public class GetVehiculoDto : VehiculoDto
    {
        public int IdVehiculo { get; set; }
        public bool Activo { get; set; }
    }
}
