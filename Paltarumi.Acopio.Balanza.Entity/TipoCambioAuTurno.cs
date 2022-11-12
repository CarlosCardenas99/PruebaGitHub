using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoCambioAuTurno
    {
        public TipoCambioAuTurno()
        {
            TipoCambioAus = new HashSet<TipoCambioAu>();
        }

        public string IdTipoCambioAuTurno { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<TipoCambioAu> TipoCambioAus { get; set; }
    }
}
