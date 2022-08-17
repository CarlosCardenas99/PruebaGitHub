using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class MuestraEstado
    {
        public MuestraEstado()
        {
            LoteCodigoMuestreos = new HashSet<LoteCodigoMuestreo>();
        }

        public string IdMuestraEstado { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteCodigoMuestreo> LoteCodigoMuestreos { get; set; }
    }
}
