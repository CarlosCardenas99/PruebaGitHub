using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoEnsayoDetalle
    {
        public int IdLoteCodigoEnsayoDetalle { get; set; }
        public int IdLoteCodigoEnsayo { get; set; }
        public string IdLoteCodigoEnsayoOrigen { get; set; } = null!;
        public int? WMuestra { get; set; }
        public decimal? WDore { get; set; }
        public decimal? WAu { get; set; }
        public float? WAg { get; set; }
        public float? LeyAuGt { get; set; }
        public float? LeyAuOzTc { get; set; }
        public float? LeyAgGt { get; set; }
        public float? LeyAgOzTc { get; set; }
        public int? PesoTotal { get; set; }
        public decimal? PesoFino { get; set; }
        public decimal? PesoGrueso { get; set; }
        public decimal? PesoFinoEnsayo { get; set; }
        public decimal? AuFinoEnsayo { get; set; }
        public decimal? AuGruesoEnsayo { get; set; }
        public float? LeyGt { get; set; }
        public float? LeyOzTc { get; set; }
        public float? PorcentajeFino { get; set; }
        public float? PorcentajeGrueso { get; set; }
        public bool? Activo { get; set; }

        public virtual LoteCodigoEnsayoOrigen IdLoteCodigoEnsayoOrigenNavigation { get; set; } = null!;
    }
}
