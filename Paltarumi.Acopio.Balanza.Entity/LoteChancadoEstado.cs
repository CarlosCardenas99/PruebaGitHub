using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteChancadoEstado
    {
        public LoteChancadoEstado()
        {
            LoteChancados = new HashSet<LoteChancado>();
        }

        public string IdLoteChancadoEstado { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteChancado> LoteChancados { get; set; }
    }
}
