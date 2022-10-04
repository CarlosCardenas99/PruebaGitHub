using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacionGasto
    {
        public int IdLoteLiquidacionGasto { get; set; }
        public int IdLoteLiquidacion { get; set; }
        public string IdTipoGasto { get; set; } = null!;
        public string IdSucursal { get; set; } = null!;
        public decimal TipoCambio { get; set; }
        public string IdMoneda { get; set; } = null!;
        public decimal ValorUnitarioTmhOriginal { get; set; }
        public decimal ValorUnitarioTmh { get; set; }
        public decimal SubTotal { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual LoteLiquidacion IdLoteLiquidacionNavigation { get; set; } = null!;
        public virtual Monedum IdMonedaNavigation { get; set; } = null!;
        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
        public virtual TipoGasto IdTipoGastoNavigation { get; set; } = null!;
    }
}
