using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class MineralCondicion
    {
        public MineralCondicion()
        {
            LoteChancados = new HashSet<LoteChancado>();
            LoteMuestreos = new HashSet<LoteMuestreo>();
        }

        public string IdMineralCondicion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteChancado> LoteChancados { get; set; }
        public virtual ICollection<LoteMuestreo> LoteMuestreos { get; set; }
    }
}
