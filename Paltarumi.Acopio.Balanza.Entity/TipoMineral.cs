using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoMineral
    {
        public TipoMineral()
        {
            LoteLiquidacions = new HashSet<LoteLiquidacion>();
            LoteMuestreos = new HashSet<LoteMuestreo>();
        }

        public string IdTipoMineral { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteLiquidacion> LoteLiquidacions { get; set; }
        public virtual ICollection<LoteMuestreo> LoteMuestreos { get; set; }
    }
}
