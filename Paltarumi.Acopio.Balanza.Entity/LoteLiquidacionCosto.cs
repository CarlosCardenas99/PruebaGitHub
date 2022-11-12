using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionCosto
    {
        public int IdLoteLiquidacionCosto { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public int IdConceptoCosto { get; set; }
        public decimal ValorConvertido { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; }

        public virtual ConceptoCosto IdConceptoCostoNavigation { get; set; } = null!;
    }
}
