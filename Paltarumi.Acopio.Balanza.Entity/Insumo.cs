using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Insumo
    {
        public Insumo()
        {
            LoteLiquidacionConsumos = new HashSet<LoteLiquidacionConsumo>();
        }

        public string IdInsumo { get; set; } = null!;
        public string Simbolo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<LoteLiquidacionConsumo> LoteLiquidacionConsumos { get; set; }
    }
}
