using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionGasto
    {
        public int IdLoteLiquidacionGasto { get; set; }
        public int IdComprobanteDetalle { get; set; }
        public float ValorUnitarioTmh { get; set; }
        public decimal SubTotalAsignado { get; set; }
        public bool Activo { get; set; }

        public virtual ComprobanteDetalle IdComprobanteDetalleNavigation { get; set; } = null!;
    }
}
