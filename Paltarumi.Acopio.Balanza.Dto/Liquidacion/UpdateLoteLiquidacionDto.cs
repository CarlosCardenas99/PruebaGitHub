namespace Paltarumi.Acopio.Balanza.Dto.Liquidacion
{
    public class UpdateLoteLiquidacionDto
    {
        public string CodigoLote { get; set; } = null!;
        public int IdProveedor { get; set; }
        public decimal Tmh100 { get; set; }
        public decimal Tmh { get; set; }
    }
}
