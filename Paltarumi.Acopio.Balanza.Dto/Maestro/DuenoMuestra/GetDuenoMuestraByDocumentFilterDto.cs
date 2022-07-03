namespace Paltarumi.Acopio.Maestro.Dto.DuenoMuestra
{
    public class GetDuenoMuestraByDocumentFilterDto
    {
        public string Numero { get; set; } = null!;
        public string? CodigoTipoDocumento { get; set; }
    }
}
