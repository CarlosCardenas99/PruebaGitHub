﻿using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class TipoComprobante
    {
        public TipoComprobante()
        {
            ComprobanteGrupoDetalles = new HashSet<ComprobanteGrupoDetalle>();
            Comprobantes = new HashSet<Comprobante>();
        }

        public string IdTipoComprobante { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string NombreCorto { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<ComprobanteGrupoDetalle> ComprobanteGrupoDetalles { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
