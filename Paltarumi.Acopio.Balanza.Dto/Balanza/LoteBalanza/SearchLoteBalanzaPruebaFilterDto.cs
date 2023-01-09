namespace Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanza
{
    public class SearchLoteBalanzaPruebaFilterDto
    {
        public string CodigoLote { get; set; } = null!;
        public string? ProveedorRuc { get; set; }
        public decimal Tmh { get; set; }
        public DateTimeOffset? FechaDesde { get; set; }
        public DateTimeOffset? FechaHasta { get; set; }
    }
}
