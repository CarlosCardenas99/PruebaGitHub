
namespace Paltarumi.Acopio.Domain.Dto.Maestro.CheckList
{
    public class SearchCheckListDto
    {
        public string Codigo { get; set; } = null!;
        public DateTimeOffset? FechaIngreso { get; set; }
        public string Usuario { get; set; } = null!;
        public DateTimeOffset? FechaRecepcion { get; set; }
        public string NombreProveedor { get; set; } = null!;
        public string Ruc { get; set; } = null!;
        public string Comunero { get; set; } = null!;
        public int EstadoPorcentual { get; set; }
    }
}
