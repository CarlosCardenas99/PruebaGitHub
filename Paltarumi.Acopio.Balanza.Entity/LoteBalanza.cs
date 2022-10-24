using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteBalanza
    {
        public LoteBalanza()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdLoteBalanza { get; set; }
        public string CodigoLote { get; set; } = null!;
        public string? CodigoTrujillo { get; set; }
        public string? CodigoAum { get; set; }
        public int IdConcesion { get; set; }
        public int IdProveedor { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public DateTimeOffset? FechaAcopio { get; set; }
        public int IdEstadoTipoMaterial { get; set; }
        public int CantidadSacos { get; set; }
        public decimal Tmh100 { get; set; }
        public decimal TmhBase { get; set; }
        public decimal Tmh { get; set; }
        public decimal? Humedad { get; set; }
        public decimal? Tms { get; set; }
        public string Observacion { get; set; } = null!;
        public int PorcentajeCheckList { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
        public string IdLoteEstado { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;
        public int IdCorrelativo { get; set; }

        public virtual Concesion IdConcesionNavigation { get; set; } = null!;
        public virtual Correlativo IdCorrelativoNavigation { get; set; } = null!;
        public virtual Maestro IdEstadoTipoMaterialNavigation { get; set; } = null!;
        public virtual LoteEstado IdLoteEstadoNavigation { get; set; } = null!;
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
