namespace Paltarumi.Acopio.Domain.Dto.Maestro.TipoDocumento
{
    public class GetTipoDocumentoDto : TipoDocumentoDto
    {
        public int IdTipoDocumento { get; set; }
        public bool Activo { get; set; }
    }
}
