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
        public decimal TipoCambio { get; set; }
        public string IdMoneda { get; set; } = null!;
        public string IdMonedaCalculo { get; set; } = null!;
        public decimal SubTotalSoles { get; set; }
        public decimal SubTotalDolares { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
