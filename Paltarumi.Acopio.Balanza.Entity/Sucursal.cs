using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            LiquidacionGastos = new HashSet<LiquidacionGasto>();
        }

        public string IdSucursal { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LiquidacionGasto> LiquidacionGastos { get; set; }
    }
}
