
namespace Paltarumi.Acopio.Balanza.Dto.LoteCodigo
{
    public class LoteCodigoDto
    {
        public int? IdLoteBalanza { get; set; }
        public int? IdDuenoMuestra { get; set; }
        public int IdTipoLoteCodigo { get; set; }
        public DateTimeOffset FechaRecepcion { get; set; }
        public string? HoraRecepcion { get; set; }
        public string? CodigoPlanta { get; set; }
        public string? CodigoExterno { get; set; }
        public string? CodigoHash { get; set; }
        public bool EnsayoLeyAu { get; set; }
        public bool EnsayoLeyAg { get; set; }
        public bool EnsayoPorcentajeRecuperacion { get; set; }
        public bool EnsayoConsumo { get; set; }
        public int IdEstado { get; set; }
        public string? UserNameCreate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}
