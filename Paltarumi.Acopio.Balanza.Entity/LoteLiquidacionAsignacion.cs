using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionAsignacion
    {
        public int IdLoteLiquidacionAsignacion { get; set; }
        public int IdComprobanteDetalle { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal SubTotalSolesProveedor { get; set; }
        public decimal SubTotalSolesEmpresa { get; set; }
        public decimal SubTotalDolaresProveedor { get; set; }
        public decimal SubTotalDolaresEmpresa { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ComprobanteDetalle IdComprobanteDetalleNavigation { get; set; } = null!;
        public virtual LoteLiquidacion IdLoteLiquidacionNavigation { get; set; } = null!;
    }
}
