namespace Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion
{
    public class CreateOrUpdateLoteOperacionDto
    {
        public string Modulo { get; set; } = null!;
        public string Operacion { get; set; } = null!;
        public string CodigoLote { get; set; } = null!;
        public string Body { get; set; } = null!;
        public Exception Exception { get; set; } = null!;
    }
}
