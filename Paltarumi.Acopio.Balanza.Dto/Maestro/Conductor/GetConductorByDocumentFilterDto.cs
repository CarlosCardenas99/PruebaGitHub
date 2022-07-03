namespace Paltarumi.Acopio.Maestro.Dto.Conductor
{
    public class GetConductorByDocumentFilterDto
    {
        public string? CodigoTipoDocumento { get; set; }
        public string Numero { get; set; } = null!;
    }
}
