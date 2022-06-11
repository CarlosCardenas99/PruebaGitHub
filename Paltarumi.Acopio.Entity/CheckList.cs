using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class CheckList
    {
        public CheckList()
        {
            LoteCheckLists = new HashSet<LoteCheckList>();
        }

        public int IdCheckList { get; set; }
        public int IdModulo { get; set; }
        public string Concepto { get; set; } = null!;
        public bool Mandatorio { get; set; }
        public bool Activo { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; } = null!;
        public virtual ICollection<LoteCheckList> LoteCheckLists { get; set; }
    }
}
