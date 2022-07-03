using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class ItemCheck
    {
        public int IdItemCheck { get; set; }
        public string Concepto { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
