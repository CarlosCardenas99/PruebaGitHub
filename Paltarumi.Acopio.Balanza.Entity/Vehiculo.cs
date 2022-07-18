namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Tickets = new HashSet<Ticket>();
            TransporteVehiculos = new HashSet<TransporteVehiculo>();
        }

        public int IdVehiculo { get; set; }
        public int IdTipoVehiculo { get; set; }
        public int IdVehiculoMarca { get; set; }
        public string Placa { get; set; } = null!;
        public string PlacaCarreta { get; set; } = null!;
        public decimal Tara { get; set; }
        public bool Activo { get; set; }

        public virtual Maestro IdTipoVehiculoNavigation { get; set; } = null!;
        public virtual Maestro IdVehiculoMarcaNavigation { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<TransporteVehiculo> TransporteVehiculos { get; set; }
    }
}
