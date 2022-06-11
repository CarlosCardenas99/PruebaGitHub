using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class LoteCodigo
    {
        public int IdLoteCodigo { get; set; }
        public int IdLote { get; set; }
        public DateTime Fecha { get; set; }
        public string LoteCodigo1 { get; set; } = null!;
        public string LoteCodigoHash { get; set; } = null!;
        public int IdEstado { get; set; }
        public bool Activo { get; set; }
    }
}
