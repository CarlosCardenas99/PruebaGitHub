using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Ley
    {
        public int IdLey { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public int IdLoteCodigo { get; set; }
        public string CodigoPlanta { get; set; } = null!;
        public decimal Tms { get; set; }
        public decimal? LeyAuGt100 { get; set; }
        public decimal? LeyAuOzTc100 { get; set; }
        public decimal? LeyAuGt { get; set; }
        public decimal? LeyAuOzTc { get; set; }
        public decimal? Dilucion { get; set; }
        public decimal? Diferencia { get; set; }
        public decimal? Total { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }
    }
}
