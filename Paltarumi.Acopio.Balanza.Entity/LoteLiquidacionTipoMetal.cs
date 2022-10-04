using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionTipoMetal
    {
        public int IdLoteLiquidacionTipoMetal { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public string IdTipoMetal { get; set; } = null!;
        public decimal RiesgoComercial { get; set; }
        public decimal LeyGt100Newmont { get; set; }
        public decimal LeyOzTc100Newmont { get; set; }
        public decimal LeyGtNewmont { get; set; }
        public decimal LeyOzTcNewmont { get; set; }
        public decimal PorcentajeRecuperacion100 { get; set; }
        public decimal Recuperacion100GrTm { get; set; }
        public decimal PorcentajeRecuperacion { get; set; }
        public decimal RecuperacionGrTm { get; set; }
        public decimal TotalRecuperacion100Gr { get; set; }
        public decimal TotalRecuperacionGr { get; set; }
        public decimal DiferenciaTotalRecuperacionGr { get; set; }
        public decimal ValorUnitarioSinPenalidadTm { get; set; }
        public decimal SubTotalSinPenalidad { get; set; }
        public bool Activo { get; set; }

        public virtual LoteLiquidacion IdLoteLiquidacionNavigation { get; set; } = null!;
        public virtual TipoMetal IdTipoMetalNavigation { get; set; } = null!;
    }
}
