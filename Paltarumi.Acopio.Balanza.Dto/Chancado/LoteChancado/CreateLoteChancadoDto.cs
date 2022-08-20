namespace Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado
{
    public class CreateLoteChancadoDto
    {
        public string CodigoLote { get; set; } = null!;
        public string PlacasTicket { get; set; } = null!;
        public string PlacasCarretaTicket { get; set; } = null!;
        public int IdProveedor { get; set; }
        public float Tmh { get; set; }
    }
}
