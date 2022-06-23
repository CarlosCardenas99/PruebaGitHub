namespace Paltarumi.Acopio.Entity
{
    public partial class LoteBalanza
    {
        public LoteBalanza()
        {
            CheckLists = new HashSet<CheckList>();
            LoteCodigos = new HashSet<LoteCodigo>();
            Tickets = new HashSet<Ticket>();
        }

        public int IdLoteBalanza { get; set; }
        public string Codigo { get; set; } = null!;
        public int IdConcesion { get; set; }
        public int IdProveedor { get; set; }
        public string Vehiculos { get; set; } = null!;
        public string Transportistas { get; set; } = null!;
        public string NumeroTickets { get; set; } = null!;
        public string Conductores { get; set; } = null!;
        public DateTimeOffset FechaIngreso { get; set; }
        public string HoraIngreso { get; set; } = null!;
        public DateTimeOffset? FechaAcopio { get; set; }
        public string? HoraAcopio { get; set; }
        public int IdEstadoTipoMaterial { get; set; }
        public string CantidadSacos { get; set; } = null!;
        public float Tmh100 { get; set; }
        public float TmhBase { get; set; }
        public float Tmh { get; set; }
        public float? Humedad100 { get; set; }
        public float? HumedadBase { get; set; }
        public float? Humedad { get; set; }
        public float Tms100 { get; set; }
        public float TmsBase { get; set; }
        public float? Tms { get; set; }
        public int IdEstado { get; set; }
        public string Observacion { get; set; } = null!;
        public int PorcentajeCheckList { get; set; }
        public int IdUsuarioCreate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public int? IdUsuarioUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }

        public virtual Concesion IdConcesionNavigation { get; set; } = null!;
        public virtual Maestro IdEstadoNavigation { get; set; } = null!;
        public virtual Maestro IdEstadoTipoMaterialNavigation { get; set; } = null!;
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual ICollection<CheckList> CheckLists { get; set; }
        public virtual ICollection<LoteCodigo> LoteCodigos { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
