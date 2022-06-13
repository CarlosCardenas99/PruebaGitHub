namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo
{
    public class SearchLoteCodigoFilterDto
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string? Codigo { get; set; }
        public string? Proveedor { get; set; } // Ruc o Razón Social

    }
}
