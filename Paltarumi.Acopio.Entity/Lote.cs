namespace Paltarumi.Acopio.Entity
{
    public partial class Lote
    {
        public Lote()
        {
            TicketsNavigation = new HashSet<Ticket>();
        }

        public int IdLote { get; set; }
        public string Codigo { get; set; } = null!;
        public int IdConcesion { get; set; }
        public int IdProveedor { get; set; }
        public string Vehiculos { get; set; } = null!;
        public string Transportistas { get; set; } = null!;
        public string Tickets { get; set; } = null!;
        public string Conductores { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public string HoraIngreso { get; set; } = null!;
        public DateTime FechaAcopio { get; set; }
        public string HoraAcopio { get; set; } = null!;
        public int IdEstadoTipoMaterial { get; set; }
        public string CantidadSacos { get; set; } = null!;
        public float Tmh100 { get; set; }
        public float TmhBase { get; set; }
        public float Tmh { get; set; }
        public float Humedad { get; set; }
        public float Tms { get; set; }
        public int CodigoEstado { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual Concesion IdConcesionNavigation { get; set; } = null!;
        public virtual Maestro IdEstadoTipoMaterialNavigation { get; set; } = null!;
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual ICollection<Ticket> TicketsNavigation { get; set; }
    }
}
