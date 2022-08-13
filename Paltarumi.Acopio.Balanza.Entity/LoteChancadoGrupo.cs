using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteChancadoGrupo
    {
        public string IdLoteChancadoGrupo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }
    }
}
