using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoEnsayoOrigen
    {
        public LoteCodigoEnsayoOrigen()
        {
            LoteCodigoEnsayoDetalles = new HashSet<LoteCodigoEnsayoDetalle>();
        }

        public string IdLoteCodigoEnsayoOrigen { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteCodigoEnsayoDetalle> LoteCodigoEnsayoDetalles { get; set; }
    }
}
