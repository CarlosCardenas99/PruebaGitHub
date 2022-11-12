using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoModulo
    {
        public LoteCodigoModulo()
        {
            LoteCodigos = new HashSet<LoteCodigo>();
        }

        public string IdLoteCodigoModulo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Nivel { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteCodigo> LoteCodigos { get; set; }
    }
}
