using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class LoteCheckList
    {
        public int IdLoteCheckList { get; set; }
        public int IdLote { get; set; }
        public int IdCheckList { get; set; }
        public string? NumeroDocumento { get; set; }
        public string Adjunto { get; set; } = null!;
        public int IdCheckListEstado { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Habilitado { get; set; }
        public bool Activo { get; set; }

        public virtual Maestro IdCheckListEstadoNavigation { get; set; } = null!;
        public virtual CheckList IdCheckListNavigation { get; set; } = null!;
        public virtual Lote IdLoteNavigation { get; set; } = null!;
    }
}
