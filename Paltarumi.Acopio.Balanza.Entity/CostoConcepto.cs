using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class CostoConcepto
    {
        public CostoConcepto()
        {
            Costos = new HashSet<Costo>();
        }

        public string IdCostoConcepto { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Costo> Costos { get; set; }
    }
}
