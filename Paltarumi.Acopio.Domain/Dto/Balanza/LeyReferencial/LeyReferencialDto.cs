
namespace Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial
{
    public class LeyReferencialDto
    {
        public DateTimeOffset FechaRecepcion { get; set; }
        public int IdDuenoMuestra { get; set; }
        public string CodigoMuestraProveedor { get; set; } = null!;
        public string CodigoPlanta { get; set; } = null!;
        public int? IdTipoMineral { get; set; }
        public int CodigoHash { get; set; }
        public bool EnsayoLeyAu { get; set; }
        public bool EnsayoLeyAg { get; set; }
        public bool EnsayoPorcentajeRecuperacion { get; set; }
        public bool EnsayoConsumo { get; set; }
    }
}
