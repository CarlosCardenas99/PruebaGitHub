using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoEnsayoEstado
    {
        public LoteCodigoEnsayoEstado()
        {
            LoteCodigoEnsayos = new HashSet<LoteCodigoEnsayo>();
        }

        public string IdLoteCodigoEnsayoEstado { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteCodigoEnsayo> LoteCodigoEnsayos { get; set; }
    }
}
