
namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo
{
    public class LoteCodigoDto
    {
		public int IdLote { get; set; }
		public DateTime Fecha { get; set; }
		public string LoteCodigo { get; set; }
		public string LoteCodigoHash { get; set; }
		public int IdEstado { get; set; }
    }
}
