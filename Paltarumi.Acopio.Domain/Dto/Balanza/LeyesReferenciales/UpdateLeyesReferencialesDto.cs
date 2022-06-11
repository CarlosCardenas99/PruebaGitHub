namespace Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales
{
    public class UpdateLeyesReferencialesDto : LeyesReferencialesDto
    {
        public int IdLeyesReferenciales { get; set; }
        public bool Activo { get; set; }
    }
}
