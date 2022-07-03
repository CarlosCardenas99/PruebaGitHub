namespace Paltarumi.Acopio.Balanza.Dto.Acopio.Operacion
{
    public class OperacionDto
    {
        public int IdModulo { get; set; }
        public string Codigo { get; set; } = null!;
        public string PushUrl { get; set; } = null!;
        public string NotificationEmail { get; set; } = null!;
    }
}
