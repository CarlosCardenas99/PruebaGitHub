namespace Paltarumi.Acopio.Balanza.Dto.LoteCodigo
{
    public class SearchLoteCodigoFilterDto
    {
        public DateTimeOffset? FechaDesde { get; set; }
        public DateTimeOffset? FechaHasta { get; set; }
        public string? CodigoLote { get; set; }
        public string? Proveedor { get; set; } // Ruc o Raz�n Social
    }
}
