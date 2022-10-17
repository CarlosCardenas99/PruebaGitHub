using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoLiquidacion
    {
        public TipoLiquidacion()
        {
            LoteLiquidacions = new HashSet<LoteLiquidacion>();
        }

        public string IdTipoLiquidacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteLiquidacion> LoteLiquidacions { get; set; }
    }
}
