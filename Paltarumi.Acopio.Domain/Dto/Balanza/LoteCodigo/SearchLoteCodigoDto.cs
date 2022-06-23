
namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo
{
    public class SearchLoteCodigoDto
    {
        public DateTimeOffset FechaRecepcion { get; set; }
        public string? loteCodigo { get; set; }
        public string? Proveedor { get; set; }
        public string CodigoMuestra { get; set; } = null!;
        public string CodigoPlanta { get; set; } = null!;
        public string CodigoHash { get; set; } = null!;
        public bool EnsayoLeyAu { get; set; }
        public bool EnsayoLeyAg { get; set; }
        public bool EnsayoPorcentajeRecuperacion { get; set; }
        public bool EnsayoConsumo { get; set; }
        public int IdUsuarioCreate { get; set; }
        public string Estado { get; set; } = null!;

    }
}
