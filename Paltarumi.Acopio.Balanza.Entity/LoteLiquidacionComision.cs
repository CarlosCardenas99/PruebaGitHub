using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionComision
    {
        public LoteLiquidacionComision()
        {
            LoteLiquidacionComisionAsignacions = new HashSet<LoteLiquidacionComisionAsignacion>();
        }

        public int IdLoteLiquidacionComision { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public int IdComisionistum { get; set; }
        public string IdComisionEstado { get; set; } = null!;
        public decimal PorcentajeComision { get; set; }
        public string IdDivisa { get; set; } = null!;
        public decimal ValorComision100 { get; set; }
        public decimal ValorComision { get; set; }
        public bool Activo { get; set; }

        public virtual ComisionEstado IdComisionEstadoNavigation { get; set; } = null!;
        public virtual Comisionistum IdComisionistumNavigation { get; set; } = null!;
        public virtual Divisa IdDivisaNavigation { get; set; } = null!;
        public virtual LoteLiquidacion IdLoteLiquidacionNavigation { get; set; } = null!;
        public virtual ICollection<LoteLiquidacionComisionAsignacion> LoteLiquidacionComisionAsignacions { get; set; }
    }
}
