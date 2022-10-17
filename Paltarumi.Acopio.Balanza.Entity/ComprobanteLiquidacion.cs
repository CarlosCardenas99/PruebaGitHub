using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ComprobanteLiquidacion
    {
        public int IdComprobanteLiquidacion { get; set; }
        public int IdComprobante { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public bool Activo { get; set; }
    }
}
