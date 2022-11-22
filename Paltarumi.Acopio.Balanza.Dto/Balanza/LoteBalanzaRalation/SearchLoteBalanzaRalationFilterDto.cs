namespace Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation
{
    public class SearchLoteBalanzaRalationFilterDto
    {
        public DateTimeOffset? FechaDesde { get; set; }
        public DateTimeOffset? FechaHasta { get; set; }
        public string? CodigoLote { get; set; }
        public string? Proveedor { get; set; }
        public bool Relacionado { get; set; }
    }
}
