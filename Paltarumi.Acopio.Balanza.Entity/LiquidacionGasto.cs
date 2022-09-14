using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LiquidacionGasto
    {
        public int IdLiquidacionGasto { get; set; }
        public int IdGasto { get; set; }
        public string IdSucursal { get; set; } = null!;
        public decimal TipoCambio { get; set; }
        public decimal Cantidad { get; set; }
        public string IdMoneda { get; set; } = null!;
        public decimal Costo { get; set; }
        public decimal CostoDolares { get; set; }
        public decimal TotalDolares { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual Gasto IdGastoNavigation { get; set; } = null!;
        public virtual Monedum IdMonedaNavigation { get; set; } = null!;
        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
    }
}
