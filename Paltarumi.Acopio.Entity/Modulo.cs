using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Modulo
    {
        public Modulo()
        {
            CheckLists = new HashSet<CheckList>();
        }

        public int IdModulo { get; set; }
        public string Nombre { get; set; } = null!;
        public int Estado { get; set; }

        public virtual ICollection<CheckList> CheckLists { get; set; }
    }
}
