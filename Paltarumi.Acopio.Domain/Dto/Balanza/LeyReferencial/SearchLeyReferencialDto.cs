
namespace Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial
{
    public class SearchLeyReferencialDto: LeyReferencialDto
    {
        public string? TipoMineral { get; set; }
        public string? DuenoMuestra { get; set; }
        public string? Proveedor { get; set; }
        public int? IdLeyReferencial { get; set; }
    }
}
