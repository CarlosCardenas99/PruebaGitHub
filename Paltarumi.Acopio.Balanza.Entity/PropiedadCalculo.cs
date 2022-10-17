using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class PropiedadCalculo
    {
        public PropiedadCalculo()
        {
            ComprobanteDetalles = new HashSet<ComprobanteDetalle>();
            LoteLiquidacionConsumos = new HashSet<LoteLiquidacionConsumo>();
        }

        public string IdPropiedadCalculo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<ComprobanteDetalle> ComprobanteDetalles { get; set; }
        public virtual ICollection<LoteLiquidacionConsumo> LoteLiquidacionConsumos { get; set; }
    }
}
