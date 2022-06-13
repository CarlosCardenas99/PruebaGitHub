using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Modulo
    {
        public Modulo()
        {
            ItemChecks = new HashSet<ItemCheck>();
        }

        public int IdModulo { get; set; }
        public string Nombre { get; set; } = null!;
        public int Nivel { get; set; }
        public int Activo { get; set; }

        public virtual ICollection<ItemCheck> ItemChecks { get; set; }
    }
}
