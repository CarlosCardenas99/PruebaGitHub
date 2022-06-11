using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class LeyReferencial
    {
        public int IdLeyReferencial { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int IdDuenoMuestra { get; set; }
        public int? IdProveedor { get; set; }
        public string CodigoMuestraProveedor { get; set; } = null!;
        public string CodigoPlanta { get; set; } = null!;
        public int? IdTipoMineral { get; set; }
        public int CodigoLaboratorio { get; set; }
        public bool LeyAu { get; set; }
        public bool LeyAg { get; set; }
        public bool PorcentajeRecuperacion { get; set; }
        public bool Consumos { get; set; }
        public bool Activo { get; set; }

        public virtual DuenoMuestra IdDuenoMuestraNavigation { get; set; } = null!;
        public virtual Proveedor? IdProveedorNavigation { get; set; }
        public virtual Maestro? IdTipoMineralNavigation { get; set; }
    }
}
