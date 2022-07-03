namespace Paltarumi.Acopio.Dto.Maestro.Vehiculo
{
    public class UpdateVehiculoDto : VehiculoDto
    {
        public int IdVehiculo { get; set; }
        public string? DescripcionTipoVehiculo { get; set; }
        public string? DescripcionVehiculoMarca { get; set; }
        public bool Activo { get; set; }
    }
}
