
namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo
{
    public class SearchLoteCodigoDto
    {
        public int? IdLoteCodigo { get; set; }
        public string Codigo { get; set; } = null!;
        public string? Proveedor { get; set; }
        public int IdUsuarioCreate { get; set; }
        public string CodigoHash { get; set; } = null!;
        public DateTime FechaRecepcion { get; set; }
        public DateTime CreateDate { get; set; }
        public string Estado { get; set; } = null!;
    }
}
