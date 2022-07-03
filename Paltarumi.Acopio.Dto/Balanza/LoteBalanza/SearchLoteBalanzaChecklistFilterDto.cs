namespace Paltarumi.Acopio.Dto.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaChecklistFilterDto
    {
        public DateTimeOffset? FechaDesde { get; set; }
        public DateTimeOffset? FechaHasta { get; set; }
        public string? Codigo { get; set; }
        public string? Proveedor { get; set; } // Ruc o Razón Social
    }
}
