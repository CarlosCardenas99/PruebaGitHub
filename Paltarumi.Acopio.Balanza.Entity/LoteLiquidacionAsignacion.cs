﻿using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionAsignacion
    {
        public int IdLoteLiquidacionAsignacion { get; set; }
        public int IdComprobanteDetalle { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public int IdAsignacion { get; set; }
        public bool Activo { get; set; }

        public virtual Asignacion IdAsignacionNavigation { get; set; } = null!;
        public virtual ComprobanteDetalle IdComprobanteDetalleNavigation { get; set; } = null!;
        public virtual LoteLiquidacion IdLoteLiquidacionNavigation { get; set; } = null!;
    }
}
