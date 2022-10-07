using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class LoteLiquidacion
    {
        public LoteLiquidacion()
        {
            LoteCodigoLiquidacions = new HashSet<LoteCodigoLiquidacion>();
            LoteLiquidacionConsumos = new HashSet<LoteLiquidacionConsumo>();
            LoteLiquidacionTipoMetals = new HashSet<LoteLiquidacionTipoMetal>();
        }

        public int IdLoteLiquidacion { get; set; }
        public string IdTipoLiquidacion { get; set; } = null!;
        public string CodigoLote { get; set; } = null!;
        public string? IdTipoMineral { get; set; }
        public int IdProveedor { get; set; }
        public decimal InterDolarOz { get; set; }
        public decimal InterDolarGr { get; set; }
        public decimal PipDolarOz { get; set; }
        public decimal PipDolarGr { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public DateTimeOffset? FechaLiquidacion { get; set; }
        public decimal Tmh100 { get; set; }
        public decimal Humedad100 { get; set; }
        public decimal Tms100 { get; set; }
        public decimal Tmh { get; set; }
        public decimal Humedad { get; set; }
        public decimal Tms { get; set; }
        public decimal TmhMerma { get; set; }
        public decimal HumedadMerma { get; set; }
        public decimal TmsMerma { get; set; }
        public decimal ValorUnitarioSinPenalidadTm { get; set; }
        public decimal SubTotalSinPenalidad { get; set; }
        public decimal ValorUnitarioConPenalidadTm { get; set; }
        public decimal SubTotalConPenalidad { get; set; }
        public decimal SubTotalAdelantos { get; set; }
        public decimal ValorUnitarioTm { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal ValorUnitarioUtilidadTm { get; set; }
        public decimal SubTotalUtilidad { get; set; }
        public decimal PorcentajeUtilidad { get; set; }
        public decimal? FactorConversion100 { get; set; }
        public decimal? FactorConversion { get; set; }
        public decimal Maquila100 { get; set; }
        public decimal Maquila { get; set; }
        public decimal ConsumoCianuro100 { get; set; }
        public decimal ConsumoSoda100 { get; set; }
        public decimal ConsumoCianuro { get; set; }
        public decimal ConsumoSoda { get; set; }
        public decimal? AjusteOculto { get; set; }
        public bool Activo { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual TipoLiquidacion IdTipoLiquidacionNavigation { get; set; } = null!;
        public virtual TipoMineral? IdTipoMineralNavigation { get; set; }
        public virtual ICollection<LoteCodigoLiquidacion> LoteCodigoLiquidacions { get; set; }
        public virtual ICollection<LoteLiquidacionConsumo> LoteLiquidacionConsumos { get; set; }
        public virtual ICollection<LoteLiquidacionTipoMetal> LoteLiquidacionTipoMetals { get; set; }
    }
}
