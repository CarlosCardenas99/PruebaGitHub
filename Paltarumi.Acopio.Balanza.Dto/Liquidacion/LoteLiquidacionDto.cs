namespace Paltarumi.Acopio.Balanza.Dto.Liquidacion
{
    public class LoteLiquidacionDto
    {
        public string IdTipoLiquidacion { get; set; } = null!;
        public string IdLoteLiquidacionEstado { get; set; } = null!;
        public int IdCorrelativo { get; set; }
        public string CodigoLote { get; set; } = null!;
        public string? IdTipoMineral { get; set; }
        public int IdProveedor { get; set; }
        public decimal TipoCambio { get; set; }
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
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public decimal ValorUnitarioUtilidadTm { get; set; }
        public decimal SubTotalUtilidad { get; set; }
        public decimal PorcentajeUtilidad { get; set; }
        public decimal FactorConversion100 { get; set; }
        public decimal FactorConversion { get; set; }
        public decimal Maquila100 { get; set; }
        public decimal Maquila { get; set; }
        public decimal SubTotalConsumo100 { get; set; }
        public decimal SubTotalConsumo { get; set; }
        public decimal SubTotalGastosEmpresa { get; set; }
        public decimal SubTotalGastosProveedor { get; set; }
        public decimal AjusteOculto { get; set; }
        public decimal Incremento { get; set; }
    }
}
