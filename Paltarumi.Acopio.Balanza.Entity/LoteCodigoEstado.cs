﻿using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoEstado
    {
        public LoteCodigoEstado()
        {
            LoteCodigos = new HashSet<LoteCodigo>();
        }

        public string IdLoteCodigoEstado { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Orden { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteCodigo> LoteCodigos { get; set; }
    }
}
