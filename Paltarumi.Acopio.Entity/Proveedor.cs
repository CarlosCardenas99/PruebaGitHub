namespace Paltarumi.Acopio.Entity
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Lotes = new HashSet<Lote>();
        }

        public int IdProveedor { get; set; }
        public string Ruc { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Lote> Lotes { get; set; }
    }
}
