using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Monedum
    {
        public Monedum()
        {
            Gastos = new HashSet<Gasto>();
            LiquidacionGastos = new HashSet<LiquidacionGasto>();
        }

        public string IdMoneda { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Gasto> Gastos { get; set; }
        public virtual ICollection<LiquidacionGasto> LiquidacionGastos { get; set; }
    }
}
