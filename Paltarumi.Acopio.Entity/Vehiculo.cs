namespace Paltarumi.Acopio.Entity
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdVehiculo { get; set; }
        public int CodigoTipoVehiculo { get; set; }
        public int CodigoMarca { get; set; }
        public string Placa { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
