using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ComprobanteGrupoDetalle
    {
        public int IdComprobanteGrupoDetalle { get; set; }
        public string IdComprobanteGrupo { get; set; } = null!;
        public string IdTipoComprobante { get; set; } = null!;

        public virtual ComprobanteGrupo IdComprobanteGrupoNavigation { get; set; } = null!;
        public virtual TipoComprobante IdTipoComprobanteNavigation { get; set; } = null!;
    }
}
