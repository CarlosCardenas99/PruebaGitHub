using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteCodigoPm
    {
        public LoteCodigoPm()
        {
            LoteCodigoPmControls = new HashSet<LoteCodigoPmControl>();
        }

        public int IdLoteCodigoPm { get; set; }
        public DateTime? FechaReporte { get; set; }
        public string CodigoPlantaRandomValor { get; set; } = null!;
        public int? IdTipoMineral { get; set; }
        public int? TiempoAgitacion { get; set; }
        public float? LeyAuOzTc100 { get; set; }
        public float? LeyAuGt100 { get; set; }
        public float? LeyAuGtPm { get; set; }
        public int MuestraPesoGr { get; set; }
        public int VolumenMl { get; set; }
        public float? PesoAuMgRelave { get; set; }
        public float? PesoAuMgSolucion { get; set; }
        public float? ResiduoAuOzTc { get; set; }
        public float? ResiduoAuGrTm { get; set; }
        public float? SolucionAuGm3 { get; set; }
        public int MineralKg { get; set; }
        public float? AguaLt { get; set; }
        public float? PorcentajeMalla { get; set; }
        public int? PhNatural { get; set; }
        public float? RecuperacionAu100 { get; set; }
        public float? RecuperacionAu { get; set; }
        public float? ConsumoSoda { get; set; }
        public float? ConsumoCianuro { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<LoteCodigoPmControl> LoteCodigoPmControls { get; set; }
    }
}
