using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Monedum
    {
        public Monedum()
        {
            TipoCostos = new HashSet<TipoCosto>();
            TipoGastos = new HashSet<TipoGasto>();
        }

        public string IdMoneda { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<TipoCosto> TipoCostos { get; set; }
        public virtual ICollection<TipoGasto> TipoGastos { get; set; }
    }
}
