
namespace Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion
{
    public class RecodificacionDto
    {
        public int IdLote { get; set; }
        public DateTime FechaRecodificacion { get; set; }
        public string HoraRecodificacion { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string CodigoLaboratorio { get; set; } = null!;
    }
}
