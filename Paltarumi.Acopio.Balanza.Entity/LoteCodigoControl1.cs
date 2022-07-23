using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoControl1
    {
        public int IdLoteCodigoControl { get; set; }
        public string BloqueCodigo { get; set; } = null!;
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public bool Activo { get; set; }
    }
}
