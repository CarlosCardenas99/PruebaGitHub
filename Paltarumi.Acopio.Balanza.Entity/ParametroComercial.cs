using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class ParametroComercial
    {
        public int IdParametroComercial { get; set; }
        public int IdProveedor { get; set; }
        public string IdTipoMetal { get; set; } = null!;
        public decimal LeyOzInicial { get; set; }
        public decimal LeyOzFinal { get; set; }
        public decimal Maquila { get; set; }
        public decimal RiesgoComercial { get; set; }
        public decimal PorcentajeRecuperacion { get; set; }
        public bool Activo { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual TipoMetal IdTipoMetalNavigation { get; set; } = null!;
    }
}
