using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Gasto
    {
        public int IdGasto { get; set; }
        public string Concepto { get; set; } = null!;
        public byte Orden { get; set; }
        public string IdMoneda { get; set; } = null!;
        public decimal Costo { get; set; }
        public bool Activo { get; set; }

        public virtual Monedum IdMonedaNavigation { get; set; } = null!;
    }
}
