using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoPmControl
    {
        public int IdLoteCodigoPmControl { get; set; }
        public int IdLoteCodigoPm { get; set; }
        public int HoraControl { get; set; }
        public decimal AdicionSoda { get; set; }
        public decimal FuerzaCianuro { get; set; }
        public string Observacion { get; set; } = null!;
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }

        public virtual LoteCodigoPm IdLoteCodigoPmNavigation { get; set; } = null!;
    }
}
