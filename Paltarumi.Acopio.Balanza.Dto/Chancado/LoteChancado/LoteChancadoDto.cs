namespace Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado
{
    public class LoteChancadoDto
    {
        public string CodigoLote { get; set; } = null!;
        public DateTimeOffset? FechaRecepcion { get; set; }
        public string? IdMineralCondicion { get; set; }
        public float Tmh { get; set; }
        public int IdProveedor { get; set; }
        public string PlacasTicket { get; set; } = null!;
        public string PlacasCarretaTicket { get; set; } = null!;
        public string? Placa { get; set; }
        public string? PlacaCarreta { get; set; }
        public string? IdLoteChancadoEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public string ObservacionBalanza { get; set; } = null!;
        public string? IdLoteEstado { get; set; }

    }
}
