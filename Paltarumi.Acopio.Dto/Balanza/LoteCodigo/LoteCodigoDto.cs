
namespace Paltarumi.Acopio.Dto.Balanza.LoteCodigo
{
    public class LoteCodigoDto
    {
        public int? IdLoteBalanza { get; set; }
        public int IdDuenoMuestra { get; set; }
        public int IdTipoLoteCodigo { get; set; }
        public DateTimeOffset FechaRecepcion { get; set; }
        public string HoraRecepcion { get; set; } = null!;
        public string CodigoLote { get; set; } = null!;
        public string CodigoPlanta { get; set; } = null!;
        public string CodigoMuestra { get; set; } = null!;
        public string CodigoHash { get; set; } = null!;
        public bool EnsayoLeyAu { get; set; }
        public bool EnsayoLeyAg { get; set; }
        public bool EnsayoPorcentajeRecuperacion { get; set; }
        public bool EnsayoConsumo { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuarioCreate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}
