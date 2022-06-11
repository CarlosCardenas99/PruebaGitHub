using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class LeyReferencial
    {
        public int IdLeyReferencial { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int IdDuenoMuestra { get; set; }
        public string CodigoMuestraProveedor { get; set; } = null!;
        public string CodigoPlanta { get; set; } = null!;
        public int? IdTipoMineral { get; set; }
        public int CodigoHash { get; set; }
        public bool EnsayoLeyAu { get; set; }
        public bool EnsayoLeyAg { get; set; }
        public bool EnsayoPorcentajeRecuperacion { get; set; }
        public bool EnsayoConsumo { get; set; }
        public bool Activo { get; set; }

        public virtual DuenoMuestra IdDuenoMuestraNavigation { get; set; } = null!;
        public virtual Maestro? IdTipoMineralNavigation { get; set; }
    }
}
