namespace Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial
{
    public class UpdateLeyReferencialDto : LeyReferencialDto
    {
        public int IdLeyReferencial { get; set; }
        public bool Activo { get; set; }
    }
}
