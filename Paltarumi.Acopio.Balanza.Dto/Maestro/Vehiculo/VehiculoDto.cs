namespace Paltarumi.Acopio.Maestro.Dto.Vehiculo
{
    public class VehiculoDto
    {
        public int IdTipoVehiculo { get; set; }
        public int IdVehiculoMarca { get; set; }
        public string Placa { get; set; } = null!;
        public string PlacaCarreta { get; set; } = null!;
        public decimal Tara { get; set; }
    }
}
