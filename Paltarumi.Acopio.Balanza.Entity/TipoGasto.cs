using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoGasto
    {
        public TipoGasto()
        {
            LoteLiquidacionGastos = new HashSet<LoteLiquidacionGasto>();
        }

        public string IdTipoGasto { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public string IdMoneda { get; set; } = null!;
        public decimal? Costo { get; set; }
        public bool Activo { get; set; }

        public virtual Monedum IdMonedaNavigation { get; set; } = null!;
        public virtual ICollection<LoteLiquidacionGasto> LoteLiquidacionGastos { get; set; }
    }
}
