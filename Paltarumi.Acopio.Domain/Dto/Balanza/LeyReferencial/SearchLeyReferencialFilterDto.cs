namespace Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial
{
    public class SearchLeyReferencialFilterDto
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string? Dueno { get; set; }
    }
}
