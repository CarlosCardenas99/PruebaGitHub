namespace Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado
{
    public class UpdateLoteChancadoDto
    {
        public string CodigoLote { get; set; } = null!;
        public string PlacasTicket { get; set; } = null!;
        public string PlacasCarretaTicket { get; set; } = null!; 
        public int IdProveedor { get; set; }
        public string IdLoteEstado { get; set; } = null!;
        public string ObservacionBalanza { get; set; } = null!;
        public float Tmh { get; set; }
    }
}
