namespace Paltarumi.Acopio.Dto.Balanza.LeyReferencial
{
    public class SearchLeyReferencialDto : LeyReferencialDto
    {
        public int? IdLeyReferencial { get; set; }
        public string? TipoMineral { get; set; }
        public string? DuenoMuestra { get; set; }
        public string? Proveedor { get; set; }
    }
}
