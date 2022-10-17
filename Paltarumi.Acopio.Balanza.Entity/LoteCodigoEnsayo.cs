using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoEnsayo
    {
        public int IdLoteCodigoEnsayo { get; set; }
        public DateTimeOffset? FechaRecepcion { get; set; }
        public string CodigoPlantaRandom { get; set; } = null!;
        public string CodigoPlantaRandomValor { get; set; } = null!;
        public float Tms { get; set; }
        public float? LeyAuGt100 { get; set; }
        public float? LeyAuOzTc100 { get; set; }
        public float? LeyAuGt100Reportado { get; set; }
        public float? LeyAuOzTc100Reportado { get; set; }
        public float? LeyAuGt { get; set; }
        public float? LeyAuOzTc { get; set; }
        public float? LeyAuGtReportado { get; set; }
        public float? LeyAuOzTcReportado { get; set; }
        public float? Dilucion { get; set; }
        public float? Diferencia { get; set; }
        public float? Total { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
    }
}
