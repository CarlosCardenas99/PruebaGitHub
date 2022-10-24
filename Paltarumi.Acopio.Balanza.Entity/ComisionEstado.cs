using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ComisionEstado
    {
        public ComisionEstado()
        {
            LoteLiquidacionComisions = new HashSet<LoteLiquidacionComision>();
        }

        public string IdComisionEstado { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteLiquidacionComision> LoteLiquidacionComisions { get; set; }
    }
}
