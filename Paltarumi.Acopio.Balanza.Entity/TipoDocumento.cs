namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Conductors = new HashSet<Conductor>();
            DuenoMuestras = new HashSet<DuenoMuestra>();
            Empresas = new HashSet<Empresa>();
        }

        public string CodigoTipoDocumento { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? NombreCorto { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Conductor> Conductors { get; set; }
        public virtual ICollection<DuenoMuestra> DuenoMuestras { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
