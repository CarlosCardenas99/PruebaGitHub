using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionConsumo
    {
        public int IdLoteLiquidacionConsumo { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public string IdInsumo { get; set; } = null!;
        public decimal ConsumoKgTm100 { get; set; }
        public decimal ValorUnitarioKg100 { get; set; }
        public decimal SubTotalTm100 { get; set; }
        public bool? CalculoPorFactor { get; set; }
        public decimal Factor { get; set; }
        public decimal ConsumoKgTmBase { get; set; }
        public decimal ConsumoKgTm { get; set; }
        public decimal SubTotalTm { get; set; }
        public bool Activo { get; set; }

        public virtual Insumo IdInsumoNavigation { get; set; } = null!;
        public virtual LoteLiquidacion IdLoteLiquidacionNavigation { get; set; } = null!;
    }
}
