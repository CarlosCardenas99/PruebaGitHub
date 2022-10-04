using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            LoteLiquidacionGastos = new HashSet<LoteLiquidacionGasto>();
        }

        public string IdSucursal { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteLiquidacionGasto> LoteLiquidacionGastos { get; set; }
    }
}
