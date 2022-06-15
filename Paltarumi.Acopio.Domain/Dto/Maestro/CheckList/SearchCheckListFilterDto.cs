namespace Paltarumi.Acopio.Domain.Dto.Maestro.CheckList
{
    public class SearchCheckListFilterDto
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string? Codigo { get; set; }
        public string? Proveedor { get; set; }
    }
}
