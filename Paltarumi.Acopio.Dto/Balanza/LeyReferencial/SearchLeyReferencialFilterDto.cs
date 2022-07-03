namespace Paltarumi.Acopio.Dto.Balanza.LeyReferencial
{
    public class SearchLeyReferencialFilterDto
    {
        public DateTimeOffset? FechaDesde { get; set; }
        public DateTimeOffset? FechaHasta { get; set; }
        public string? Dueno { get; set; }
    }
}
