using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class CheckList
    {
        public int IdCheckList { get; set; }
        public int IdLoteBalanza { get; set; }
        public int IdItemCheck { get; set; }
        public string Observacion { get; set; } = null!;
        public string Adjunto { get; set; } = null!;
        public int IdCheckListEstado { get; set; }
        public bool Habilitado { get; set; }
        public bool Activo { get; set; }

        public virtual Maestro IdCheckListEstadoNavigation { get; set; } = null!;
        public virtual ItemCheck IdItemCheckNavigation { get; set; } = null!;
        public virtual LoteBalanza IdLoteBalanzaNavigation { get; set; } = null!;
    }
}
