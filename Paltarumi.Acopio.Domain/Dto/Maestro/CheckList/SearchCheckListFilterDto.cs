namespace Paltarumi.Acopio.Domain.Dto.Maestro.CheckList
{
    public class SearchCheckListFilterDto
    {
        public DateTimeOffset? FechaDesde { get; set; }
        public DateTimeOffset? FechaHasta { get; set; }
        public string? Codigo { get; set; }
        public string? Proveedor { get; set; }
    }
}
