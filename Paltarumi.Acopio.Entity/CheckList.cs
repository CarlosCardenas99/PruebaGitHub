using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class CheckList
    {
        public int IdCheckList { get; set; }
        public int IdLoteBalanza { get; set; }
        public int IdItemCheck { get; set; }
        public string Adjunto { get; set; } = null!;
        public string ObservacionBalanza { get; set; } = null!;
        public int IdCheckListEstadoBalanza { get; set; }
        public bool HabilitadoBalanza { get; set; }
        public string ObservacionComercial { get; set; } = null!;
        public int IdCheckListEstadoComercial { get; set; }
        public bool HabilitadoComercial { get; set; }
        public bool Activo { get; set; }

        public virtual Maestro IdCheckListEstadoBalanzaNavigation { get; set; } = null!;
        public virtual Maestro IdCheckListEstadoComercialNavigation { get; set; } = null!;
        public virtual ItemCheck IdItemCheckNavigation { get; set; } = null!;
        public virtual LoteBalanza IdLoteBalanzaNavigation { get; set; } = null!;
    }
}
