namespace Paltarumi.Acopio.Entity
{
    public partial class Maestro
    {
        public Maestro()
        {
            LoteBalanzaIdEstadoNavigations = new HashSet<LoteBalanza>();
            LoteBalanzaIdEstadoTipoMaterialNavigations = new HashSet<LoteBalanza>();
            LoteCodigos = new HashSet<LoteCodigo>();
            Operacions = new HashSet<Operacion>();
            TicketIdEstadoTmhNavigations = new HashSet<Ticket>();
            TicketIdUnidadMedidaNavigations = new HashSet<Ticket>();
            VehiculoIdTipoVehiculoNavigations = new HashSet<Vehiculo>();
            VehiculoIdVehiculoMarcaNavigations = new HashSet<Vehiculo>();
        }

        public int IdMaestro { get; set; }
        public string CodigoTabla { get; set; } = null!;
        public string CodigoItem { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<LoteBalanza> LoteBalanzaIdEstadoNavigations { get; set; }
        public virtual ICollection<LoteBalanza> LoteBalanzaIdEstadoTipoMaterialNavigations { get; set; }
        public virtual ICollection<LoteCodigo> LoteCodigos { get; set; }
        public virtual ICollection<Operacion> Operacions { get; set; }
        public virtual ICollection<Ticket> TicketIdEstadoTmhNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdUnidadMedidaNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdTipoVehiculoNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdVehiculoMarcaNavigations { get; set; }
    }
}
