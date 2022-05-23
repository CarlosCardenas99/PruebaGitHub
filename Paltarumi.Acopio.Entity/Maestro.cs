namespace Paltarumi.Acopio.Entity
{
    public partial class Maestro
    {
        public Maestro()
        {
            Lotes = new HashSet<Lote>();
            Tickets = new HashSet<Ticket>();
        }

        public int IdMaestro { get; set; }
        public string CodigoTabla { get; set; } = null!;
        public string CodigoItem { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Lote> Lotes { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
