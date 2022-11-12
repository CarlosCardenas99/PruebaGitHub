using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class UnidadMedidum
    {
        public UnidadMedidum()
        {
            Consumos = new HashSet<Consumo>();
            Costos = new HashSet<Costo>();
        }

        public string IdUnidadMedida { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Consumo> Consumos { get; set; }
        public virtual ICollection<Costo> Costos { get; set; }
    }
}
