using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigo
    {
        public int IdLoteCodigo { get; set; }
        public int? IdLote { get; set; }
        public int? IdDuenoMuestra { get; set; }
        public string IdLoteCodigoTipo { get; set; } = null!;
        public DateTimeOffset FechaRecepcion { get; set; }
        public string CodigoPlanta { get; set; } = null!;
        public string CodigoPlantaRandom { get; set; } = null!;
        public string CodigoMuestraProveedor { get; set; } = null!;
        public bool EnsayoLeyAu { get; set; }
        public bool EnsayoLeyAg { get; set; }
        public bool EnsayoPorcentajeRecuperacion { get; set; }
        public bool EnsayoConsumo { get; set; }
        public int IdEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public bool Activo { get; set; }

        public virtual DuenoMuestra? IdDuenoMuestraNavigation { get; set; }
        public virtual LoteCodigoTipo IdLoteCodigoTipoNavigation { get; set; } = null!;
        public virtual Lote? IdLoteNavigation { get; set; }
    }
}
