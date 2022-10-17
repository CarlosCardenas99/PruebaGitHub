using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class EnsayoLoteDetalle
    {
        public int IdEnsayoLoteDetalle { get; set; }
        public int? IdEnsayoLoteDetallePadre { get; set; }
        public decimal? WMuestra { get; set; }
        public decimal? WDore { get; set; }
        public decimal? WAu { get; set; }
        public decimal? WAg { get; set; }
        public decimal? LeyAuGt { get; set; }
        public decimal? LeyAuOzTc { get; set; }
        public decimal? LeyAgGt { get; set; }
        public decimal? LeyAgOzTc { get; set; }
        public decimal? PesoTotal { get; set; }
        public decimal? PesoFino { get; set; }
        public decimal? PesoGrueso { get; set; }
        public decimal? PesoFinoEnsayo { get; set; }
        public decimal? AuFinoEnsayo { get; set; }
        public decimal? AuGruesoEnsayo { get; set; }
        public decimal? LeyGt { get; set; }
        public decimal? LeyOzTc { get; set; }
        public decimal? PorcentajeFino { get; set; }
        public decimal? PorcentajeGrueso { get; set; }
    }
}
