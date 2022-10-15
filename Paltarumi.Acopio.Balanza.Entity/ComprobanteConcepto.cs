﻿using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ComprobanteConcepto
    {
        public ComprobanteConcepto()
        {
            ComprobanteDetalles = new HashSet<ComprobanteDetalle>();
        }

        public int IdComprobanteConcepto { get; set; }
        public string IdComprobanteGrupo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<ComprobanteDetalle> ComprobanteDetalles { get; set; }
    }
}
