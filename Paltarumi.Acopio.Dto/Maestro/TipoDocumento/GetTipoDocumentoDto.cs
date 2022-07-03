namespace Paltarumi.Acopio.Dto.Maestro.TipoDocumento
{
    public class GetTipoDocumentoDto : TipoDocumentoDto
    {
        public int IdTipoDocumento { get; set; }
        public bool Activo { get; set; }
    }
}
