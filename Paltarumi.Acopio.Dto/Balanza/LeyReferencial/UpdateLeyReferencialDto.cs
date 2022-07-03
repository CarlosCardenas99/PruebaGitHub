namespace Paltarumi.Acopio.Dto.Balanza.LeyReferencial
{
    public class UpdateLeyReferencialDto : LeyReferencialDto
    {
        public int IdLeyReferencial { get; set; }
        public bool Activo { get; set; }
    }
}
