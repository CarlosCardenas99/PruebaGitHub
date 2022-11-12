using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoCambioAg
    {
        public int IdTipoCambioAg { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Gramos { get; set; }
        public decimal Onzas { get; set; }
        public bool Activo { get; set; }
    }
}
