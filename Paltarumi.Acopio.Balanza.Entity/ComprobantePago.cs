using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ComprobantePago
    {
        public int IdComprobantePago { get; set; }
        public int IdComprobante { get; set; }
        public string IdTipoMedioPago { get; set; } = null!;
        public string NumeroBancario { get; set; } = null!;
        public DateTime FechaPago { get; set; }
        public string CodigoMoneda { get; set; } = null!;
        public decimal TipoCambio { get; set; }
        public decimal Pago { get; set; }
        public decimal PagoSoles { get; set; }
        public decimal PagoDolares { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
