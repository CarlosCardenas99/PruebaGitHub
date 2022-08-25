using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoEnsayoDetalle
    {
        public int IdLoteCodigoEnsayoDetalle { get; set; }
        public int IdLoteCodigoEnsayo { get; set; }
        public string IdLoteCodigoEnsayoOrigen { get; set; } = null!;
        public float? WMuestra { get; set; }
        public float? WDore { get; set; }
        public float? WAu { get; set; }
        public float? WAg { get; set; }
        public float? LeyAuGt { get; set; }
        public float? LeyAuOzTc { get; set; }
        public float? LeyAgGt { get; set; }
        public float? LeyAgOzTc { get; set; }
        public float? PesoTotal { get; set; }
        public float? PesoFino { get; set; }
        public float? PesoGrueso { get; set; }
        public float? PesoFinoEnsayo { get; set; }
        public float? AuFinoEnsayo { get; set; }
        public float? AuGruesoEnsayo { get; set; }
        public float? LeyGt { get; set; }
        public float? LeyOzTc { get; set; }
        public float? PorcentajeFino { get; set; }
        public float? PorcentajeGrueso { get; set; }
        public bool Activo { get; set; }

        public virtual LoteCodigoEnsayoOrigen IdLoteCodigoEnsayoOrigenNavigation { get; set; } = null!;
    }
}
