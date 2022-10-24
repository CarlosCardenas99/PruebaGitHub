using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Comprobante
    {
        public Comprobante()
        {
            ComprobanteDetalles = new HashSet<ComprobanteDetalle>();
        }

        public int IdComprobante { get; set; }
        public string IdSucursal { get; set; } = null!;
        public string IdComprobanteGrupo { get; set; } = null!;
        public string IdTipoComprobante { get; set; } = null!;
        public string Serie { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public DateTimeOffset FechaEmision { get; set; }
        public DateTimeOffset FechaVencimiento { get; set; }
        public int IdProveedor { get; set; }
        public string IdComprobanteEstado { get; set; } = null!;
        public string IdDivisa { get; set; } = null!;
        public decimal TipoCambio { get; set; }
        public byte PorcentajeDetraccion { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public decimal? Detraccion { get; set; }
        public decimal TotalNeto { get; set; }
        public decimal? SubTotalNotaCredito { get; set; }
        public decimal? SubTotalNotaDebito { get; set; }
        public string Lotes { get; set; } = null!;
        public string Glosa { get; set; } = null!;
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ComprobanteEstado IdComprobanteEstadoNavigation { get; set; } = null!;
        public virtual ComprobanteGrupo IdComprobanteGrupoNavigation { get; set; } = null!;
        public virtual Divisa IdDivisaNavigation { get; set; } = null!;
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
        public virtual TipoComprobante IdTipoComprobanteNavigation { get; set; } = null!;
        public virtual ICollection<ComprobanteDetalle> ComprobanteDetalles { get; set; }
    }
}
