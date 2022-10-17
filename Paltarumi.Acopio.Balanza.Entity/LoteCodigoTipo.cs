using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoTipo
    {
        public LoteCodigoTipo()
        {
            LoteCodigoLiquidacions = new HashSet<LoteCodigoLiquidacion>();
            LoteCodigoNomenclaturas = new HashSet<LoteCodigoNomenclatura>();
            LoteCodigos = new HashSet<LoteCodigo>();
        }

        public string IdLoteCodigoTipo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteCodigoLiquidacion> LoteCodigoLiquidacions { get; set; }
        public virtual ICollection<LoteCodigoNomenclatura> LoteCodigoNomenclaturas { get; set; }
        public virtual ICollection<LoteCodigo> LoteCodigos { get; set; }
    }
}
