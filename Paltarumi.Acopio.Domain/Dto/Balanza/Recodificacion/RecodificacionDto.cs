
namespace Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion
{
    public class RecodificacionDto
    {
		public int IdLote { get; set; }
		public DateTime FechaRecodificacion { get; set; }
		public string HoraRecodificacion { get; set; }
		public string Codigo { get; set; }
		public string CodigoLaboratorio { get; set; }
    }
}
