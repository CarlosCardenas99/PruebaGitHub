using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ComprobanteEstado
    {
        public ComprobanteEstado()
        {
            Comprobantes = new HashSet<Comprobante>();
        }

        public string IdComprobanteEstado { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
