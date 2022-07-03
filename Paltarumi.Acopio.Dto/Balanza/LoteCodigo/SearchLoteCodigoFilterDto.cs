namespace Paltarumi.Acopio.Dto.Balanza.LoteCodigo
{
    public class SearchLoteCodigoFilterDto
    {
        public DateTimeOffset? FechaDesde { get; set; }
        public DateTimeOffset? FechaHasta { get; set; }
        public string? CodigoLote { get; set; }
        public string? Proveedor { get; set; } // Ruc o Razón Social
    }
}
