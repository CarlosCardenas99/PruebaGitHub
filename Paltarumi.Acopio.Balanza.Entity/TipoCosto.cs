﻿using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoCosto
    {
        public string IdTipoCosto { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public string IdDivisa { get; set; } = null!;
        public decimal? Costo { get; set; }
        public bool Activo { get; set; }

        public virtual Divisa IdDivisaNavigation { get; set; } = null!;
    }
}
