namespace Paltarumi.Acopio.Dto.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaFilterDto
    {
        public DateTimeOffset? FechaDesde { get; set; }
        public DateTimeOffset? FechaHasta { get; set; }
        public string? CodigoLote { get; set; }
        public string? Proveedor { get; set; } // Ruc o Razón Social
        public int? idEstado { get; set; }
        public string? Vehiculos { get; set; }
        public string? NumeroTickets { get; set; }
    }
}
