using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Modulo
    {
        public int IdModulo { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Nivel { get; set; }
        public bool Activo { get; set; }
    }
}
