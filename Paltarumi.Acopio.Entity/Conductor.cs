namespace Paltarumi.Acopio.Entity
{
    public partial class Conductor
    {
        public Conductor()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdConductor { get; set; }
        public string CodigoTipoDocumento { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public string? CodigoUbigeo { get; set; }
        public string Licencia { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual TipoDocumento CodigoTipoDocumentoNavigation { get; set; } = null!;
        public virtual Ubigeo? CodigoUbigeoNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
