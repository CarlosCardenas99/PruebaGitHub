namespace Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo
{
    public class UpdateLoteMuestreoDto
    {
        public string CodigoLote { get; set; } = null!;
        public DateTimeOffset? FechaAcopio { get; set; }
        public decimal Tmh { get; set; }
        public int IdProveedor { get; set; }
        public string IdLoteEstado { get; set; } = null!;
        public string? CodigoTrujillo { get; set; }
        public string? CodigoAum { get; set; }
    }
}
