using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class CheckList
    {
        public int IdCheckList { get; set; }
        public int IdModulo { get; set; }
        public int IdItemCheck { get; set; }
        public bool Mandatorio { get; set; }
        public bool Activo { get; set; }
    }
}
