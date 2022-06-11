
namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo
{
    public class LoteCodigoDto
    {
        public int IdLote { get; set; }
        public DateTime Fecha { get; set; }
        public string LoteCodigo1 { get; set; } = null!;
        public string LoteCodigoHash { get; set; } = null!;
        public int IdEstado { get; set; }
    }
}
