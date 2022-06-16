namespace Paltarumi.Acopio.Entity
{
    public partial class Maestro
    {
        public Maestro()
        {
            CheckListIdCheckListEstadoBalanzaNavigations = new HashSet<CheckList>();
            CheckListIdCheckListEstadoComercialNavigations = new HashSet<CheckList>();
            LoteBalanzaIdEstadoNavigations = new HashSet<LoteBalanza>();
            LoteBalanzaIdEstadoTipoMaterialNavigations = new HashSet<LoteBalanza>();
            LoteCodigos = new HashSet<LoteCodigo>();
            TicketIdEstadoTmhNavigations = new HashSet<Ticket>();
            TicketIdTipoMineralNavigations = new HashSet<Ticket>();
            TicketIdUnidadMedidaNavigations = new HashSet<Ticket>();
            VehiculoIdTipoVehiculoNavigations = new HashSet<Vehiculo>();
            VehiculoIdVehiculoMarcaNavigations = new HashSet<Vehiculo>();
        }

        public int IdMaestro { get; set; }
        public string CodigoTabla { get; set; } = null!;
        public string CodigoItem { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<CheckList> CheckListIdCheckListEstadoBalanzaNavigations { get; set; }
        public virtual ICollection<CheckList> CheckListIdCheckListEstadoComercialNavigations { get; set; }
        public virtual ICollection<LoteBalanza> LoteBalanzaIdEstadoNavigations { get; set; }
        public virtual ICollection<LoteBalanza> LoteBalanzaIdEstadoTipoMaterialNavigations { get; set; }
        public virtual ICollection<LoteCodigo> LoteCodigos { get; set; }
        public virtual ICollection<Ticket> TicketIdEstadoTmhNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdTipoMineralNavigations { get; set; }
        public virtual ICollection<Ticket> TicketIdUnidadMedidaNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdTipoVehiculoNavigations { get; set; }
        public virtual ICollection<Vehiculo> VehiculoIdVehiculoMarcaNavigations { get; set; }
    }
}
