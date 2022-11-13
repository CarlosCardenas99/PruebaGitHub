using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionCosto
    {
        public int IdLoteLiquidacionCosto { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public string IdCostoConcepto { get; set; } = null!;
        public string IdUnidadMedida { get; set; } = null!;
        public decimal ValorUnitario100 { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public bool Activo { get; set; }

        public virtual CostoConcepto IdCostoConceptoNavigation { get; set; } = null!;
        public virtual UnidadMedidum IdUnidadMedidaNavigation { get; set; } = null!;
    }
}
