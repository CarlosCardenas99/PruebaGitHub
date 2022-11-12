using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoCambioAu
    {
        public int IdTipoCambioAu { get; set; }
        public DateTime Fecha { get; set; }
        public string IdTipoCambioAuTurno { get; set; } = null!;
        public decimal Gramos { get; set; }
        public decimal Onzas { get; set; }
        public bool Activo { get; set; }

        public virtual TipoCambioAuTurno IdTipoCambioAuTurnoNavigation { get; set; } = null!;
    }
}
