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
        public float? PromedioAuGt { get; set; }
        public float? PromedioAuOzTc { get; set; }
        public float? PromedioAgGt { get; set; }
        public float? PromedioAgOzTc { get; set; }
        public float? PromLeyGt { get; set; }
        public int IdEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
    }
}
