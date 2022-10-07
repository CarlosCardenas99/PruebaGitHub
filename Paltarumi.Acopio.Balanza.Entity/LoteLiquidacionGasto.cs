using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionGasto
    {
        public int IdLoteLiquidacionGasto { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public int IdComprobanteDetalleAsignacion { get; set; }
        public decimal TipoCambio { get; set; }
        public string IdMoneda { get; set; } = null!;
        public decimal SubTotalSolesProveedor { get; set; }
        public decimal SubTotalSolesEmpresa { get; set; }
        public decimal SubTotalDolaresProveedor { get; set; }
        public decimal SubTotalDolaresEmpresa { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
