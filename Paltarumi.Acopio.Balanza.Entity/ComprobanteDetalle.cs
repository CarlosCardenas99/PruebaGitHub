using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ComprobanteDetalle
    {
        public int IdComprobanteDetalle { get; set; }
        public int IdComprobante { get; set; }
        public string IdComprobanteConcepto { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; }
    }
}
