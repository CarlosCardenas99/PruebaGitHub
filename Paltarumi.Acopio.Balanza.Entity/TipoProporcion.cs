using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoProporcion
    {
        public TipoProporcion()
        {
            LoteCodigoLiquidacions = new HashSet<LoteCodigoLiquidacion>();
        }

        public string IdTipoProporcion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int Proporcion1 { get; set; }
        public int Proporcion2 { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteCodigoLiquidacion> LoteCodigoLiquidacions { get; set; }
    }
}
