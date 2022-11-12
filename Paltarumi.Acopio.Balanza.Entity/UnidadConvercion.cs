using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class UnidadConvercion
    {
        public UnidadConvercion()
        {
            ConceptoCostos = new HashSet<ConceptoCosto>();
        }

        public string IdUnidadConvercion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Valor { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<ConceptoCosto> ConceptoCostos { get; set; }
    }
}
