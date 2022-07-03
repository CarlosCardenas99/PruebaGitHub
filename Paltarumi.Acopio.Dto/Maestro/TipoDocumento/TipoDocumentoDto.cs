namespace Paltarumi.Acopio.Dto.Maestro.TipoDocumento
{
    public class TipoDocumentoDto
    {
        public string CodigoTipoDocumento { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? NombreCorto { get; set; }
    }
}
