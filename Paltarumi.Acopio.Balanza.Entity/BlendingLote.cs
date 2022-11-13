using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class BlendingLote
    {
        public int IdBlendingLote { get; set; }
        public int IdBlending { get; set; }
        public int IdLote { get; set; }
        public bool Activo { get; set; }

        public virtual Blending IdBlendingNavigation { get; set; } = null!;
        public virtual Lote IdLoteNavigation { get; set; } = null!;
    }
}
