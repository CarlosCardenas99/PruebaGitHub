using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ComprobanteDetalle
    {
        public ComprobanteDetalle()
        {
            LoteLiquidacionAsignacions = new HashSet<LoteLiquidacionAsignacion>();
            LoteLiquidacionComisionAsignacions = new HashSet<LoteLiquidacionComisionAsignacion>();
            LoteLiquidacionGastos = new HashSet<LoteLiquidacionGasto>();
        }

        public int IdComprobanteDetalle { get; set; }
        public int IdComprobante { get; set; }
        public int IdComprobanteConcepto { get; set; }
        public decimal Cantidad { get; set; }
        public string IdPropiedadCalculo { get; set; } = null!;
        public decimal ValorUnitario { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public string IdComprobanteDetalleEstado { get; set; } = null!;
        public int? IdComprobanteDetalleReferencia { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ComprobanteConcepto IdComprobanteConceptoNavigation { get; set; } = null!;
        public virtual ComprobanteDetalleEstado IdComprobanteDetalleEstadoNavigation { get; set; } = null!;
        public virtual Comprobante IdComprobanteNavigation { get; set; } = null!;
        public virtual PropiedadCalculo IdPropiedadCalculoNavigation { get; set; } = null!;
        public virtual ICollection<LoteLiquidacionAsignacion> LoteLiquidacionAsignacions { get; set; }
        public virtual ICollection<LoteLiquidacionComisionAsignacion> LoteLiquidacionComisionAsignacions { get; set; }
        public virtual ICollection<LoteLiquidacionGasto> LoteLiquidacionGastos { get; set; }
    }
}
