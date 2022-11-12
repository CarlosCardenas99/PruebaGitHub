using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ConceptoCosto
    {
        public ConceptoCosto()
        {
            LoteLiquidacionCostos = new HashSet<LoteLiquidacionCosto>();
        }

        public int IdConceptoCosto { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Valor { get; set; }
        public string IdUnidadConvercion { get; set; } = null!;
        public bool AfectoUtilidad { get; set; }
        public bool Activo { get; set; }
        public string IdDivisa { get; set; } = null!;

        public virtual Divisa IdDivisaNavigation { get; set; } = null!;
        public virtual UnidadConvercion IdUnidadConvercionNavigation { get; set; } = null!;
        public virtual ICollection<LoteLiquidacionCosto> LoteLiquidacionCostos { get; set; }
    }
}
