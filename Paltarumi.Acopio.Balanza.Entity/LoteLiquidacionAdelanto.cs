using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionAdelanto
    {
        public int IdLoteLiquidacionAdelanto { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public int IdAdelanto { get; set; }
        public decimal ValorAplicado { get; set; }
        public bool Activo { get; set; }
    }
}
