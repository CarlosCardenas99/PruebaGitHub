using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class CheckList
    {
        public int IdCheckList { get; set; }
        public int IdLote { get; set; }
        public int IdModuloOrigen { get; set; }
        public int IdCheckListConcepto { get; set; }
        public string? NumeroDocumento { get; set; }
        public string Adjunto { get; set; } = null!;
        public int IdEstadoChecklist { get; set; }
        public string ObservacionBalanza { get; set; } = null!;
        public bool VbComercial { get; set; }
        public string ObservacionComercial { get; set; } = null!;
        public bool Verificar { get; set; }
        public bool Activo { get; set; }

        public virtual Maestro IdCheckListConceptoNavigation { get; set; } = null!;
        public virtual Maestro IdEstadoChecklistNavigation { get; set; } = null!;
        public virtual Lote IdLoteNavigation { get; set; } = null!;
        public virtual Maestro IdModuloOrigenNavigation { get; set; } = null!;
    }
}
