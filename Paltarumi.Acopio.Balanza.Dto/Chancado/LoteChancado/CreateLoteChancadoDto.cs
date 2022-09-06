namespace Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado
{
    public class CreateLoteChancadoDto
    {
        public string CodigoLote { get; set; } = null!;
        public string PlacasTicket { get; set; } = null!;
        public string PlacasCarretaTicket { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public string PlacaCarreta { get; set; } = null!;
        public int IdProveedor { get; set; }
        public string ObservacionBalanza { get; set; } = null!;
        public decimal Tmh { get; set; }
        public string? IdLoteEstado { get; set; }
    }
}
