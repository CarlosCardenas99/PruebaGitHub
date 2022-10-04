using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Comprobante
    {
        public int IdComprobante { get; set; }
        public string IdTipoComprobante { get; set; } = null!;
        public string Serie { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdProveedor { get; set; }
        public string IdComprobanteEstado { get; set; } = null!;
        public byte PorcentajeDetraccion { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public decimal? Detraccion { get; set; }
        public decimal TotalNeto { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal TotalPorPagar { get; set; }
        public decimal? SubTotalNotaCredito { get; set; }
        public decimal? SubTotalNotaDebito { get; set; }
        public string Lotes { get; set; } = null!;
        public string Glosa { get; set; } = null!;
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
    }
}
