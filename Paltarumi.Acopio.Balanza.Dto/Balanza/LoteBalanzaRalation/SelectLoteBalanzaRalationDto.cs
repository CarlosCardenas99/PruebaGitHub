
namespace Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation
{
    public class SelectLoteBalanzaRalationDto
    {
        public int? IdLoteBalanzaRalation { get; set; }
        public int IdLoteBalanza { get; set; }
        public DateTimeOffset? FechaAcopio { get; set; }
        public string CodigoLote { get; set; } = null!;
        public string? CodigoTrujillo { get; set; }
        public string? CodigoAum { get; set; }
        public int IdProveedor { get; set; }
        public string? NombreProveedor { get; set; }
        public decimal Tmh100 { get; set; }
        public decimal? Humedad { get; set; }
        public decimal? Tms { get; set; }
    }
}
