using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoEnsayo
    {
        public LoteCodigoEnsayo()
        {
            LoteCodigoEnsayoDetalles = new HashSet<LoteCodigoEnsayoDetalle>();
        }

        public int IdLoteCodigoEnsayo { get; set; }
        public DateTimeOffset? FechaRecepcion { get; set; }
        public string CodigoPlantaRandom { get; set; } = null!;
        public string CodigoPlantaRandomValor { get; set; } = null!;
        public decimal? Tms { get; set; }
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
        public string IdLoteCodigoEnsayoEstado { get; set; } = null!;

        public virtual LoteCodigoEnsayoEstado IdLoteCodigoEnsayoEstadoNavigation { get; set; } = null!;
        public virtual ICollection<LoteCodigoEnsayoDetalle> LoteCodigoEnsayoDetalles { get; set; }
    }
}
