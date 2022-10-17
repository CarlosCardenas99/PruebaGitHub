using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class EnsayoLote
    {
        public int IdEnsayoLote { get; set; }
        public int? IdEnsayoLotePadre { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public int IdLoteCodigo { get; set; }
        public string CodigoPlanta { get; set; } = null!;
        public string? UserNameResponsable { get; set; }
        public decimal? PromedioAuGt { get; set; }
        public decimal? PromedioAuOzTc { get; set; }
        public decimal? PromedioAgGt { get; set; }
        public decimal? PromedioAgOzTc { get; set; }
        public decimal? PromLeyGt { get; set; }
        public int IdEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
    }
}
