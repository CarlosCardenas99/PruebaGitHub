using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ComprobanteGrupo
    {
        public ComprobanteGrupo()
        {
            Comprobantes = new HashSet<Comprobante>();
        }

        public string IdComprobanteGrupo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
