using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Gasto
    {
        public Gasto()
        {
            LiquidacionGastos = new HashSet<LiquidacionGasto>();
        }

        public int IdGasto { get; set; }
        public string Concepto { get; set; } = null!;
        public byte Orden { get; set; }
        public string IdMoneda { get; set; } = null!;
        public decimal Costo { get; set; }
        public bool Activo { get; set; }

        public virtual Monedum IdMonedaNavigation { get; set; } = null!;
        public virtual ICollection<LiquidacionGasto> LiquidacionGastos { get; set; }
    }
}
