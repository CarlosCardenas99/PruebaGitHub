using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoMetal
    {
        public TipoMetal()
        {
            LoteCodigoLiquidacions = new HashSet<LoteCodigoLiquidacion>();
            LoteLiquidacionTipoMetals = new HashSet<LoteLiquidacionTipoMetal>();
        }

        public string IdTipoMetal { get; set; } = null!;
        public string Simbolo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteCodigoLiquidacion> LoteCodigoLiquidacions { get; set; }
        public virtual ICollection<LoteLiquidacionTipoMetal> LoteLiquidacionTipoMetals { get; set; }
    }
}
