using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionComisionAsignacion
    {
        public int IdLoteLiquidacionComisionAsignacion { get; set; }
        public int IdComprobanteDetalle { get; set; }
        public int IdLoteLiquidacionComision { get; set; }
        public int IdAsignacion { get; set; }
        public bool Activo { get; set; }

        public virtual Asignacion IdAsignacionNavigation { get; set; } = null!;
        public virtual ComprobanteDetalle IdComprobanteDetalleNavigation { get; set; } = null!;
        public virtual LoteLiquidacionComision IdLoteLiquidacionComisionNavigation { get; set; } = null!;
    }
}
