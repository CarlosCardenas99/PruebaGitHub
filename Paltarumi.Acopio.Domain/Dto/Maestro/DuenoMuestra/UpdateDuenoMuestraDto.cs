namespace Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra
{
    public class UpdateDuenoMuestraDto : DuenoMuestraDto
    {
        public int IdDuenoMuestra { get; set; }
        public bool Activo { get; set; }
    }
}
