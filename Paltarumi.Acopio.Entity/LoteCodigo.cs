using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class LoteCodigo
    {
        public int IdLoteCodigo { get; set; }
        public int? IdLoteBalanza { get; set; }
        public int IdDuenoMuestra { get; set; }
        public int IdTipoLoteCodigo { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string HoraRecepcion { get; set; } = null!;
        public string CodigoPlanta { get; set; } = null!;
        public string CodigoMuestra { get; set; } = null!;
        public string CodigoHash { get; set; } = null!;
        public bool EnsayoLeyAu { get; set; }
        public bool EnsayoLeyAg { get; set; }
        public bool EnsayoPorcentajeRecuperacion { get; set; }
        public bool EnsayoConsumo { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuarioCreate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Activo { get; set; }

        public virtual DuenoMuestra IdDuenoMuestraNavigation { get; set; } = null!;
        public virtual LoteBalanza IdLoteBalanzaNavigation { get; set; } = null!;
        public virtual Maestro IdTipoLoteCodigoNavigation { get; set; } = null!;
    }
}
