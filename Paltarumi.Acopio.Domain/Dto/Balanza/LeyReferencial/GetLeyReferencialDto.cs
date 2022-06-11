namespace Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial
{
    public class GetLeyReferencialDto : LeyReferencialDto
    {
        public int IdLeyReferencial { get; set; }
        public bool Activo { get; set; }
    }
}
