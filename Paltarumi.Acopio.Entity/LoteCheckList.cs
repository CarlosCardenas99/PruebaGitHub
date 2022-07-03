using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class LoteCheckList
    {
        public int IdLoteCheckList { get; set; }
        public int IdLote { get; set; }
        public int IdCheckListEstado { get; set; }
        public bool Habilitado { get; set; }
        public string Observacion { get; set; } = null!;
        public string Adjunto { get; set; } = null!;
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
    }
}
