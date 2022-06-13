
namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo
{
    public class LoteCodigoDto
    {
        public int IdLoteBalanza { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string Codigo { get; set; } = null!;
        public string CodigoHash { get; set; } = null!;
        public int IdEstado { get; set; }
        public int IdUsuarioCreate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
