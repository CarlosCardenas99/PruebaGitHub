namespace Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado
{
    public class LoteChancadoDto
    {
        public int IdLoteBalanza { get; set; }
        public string CodigoLote { get; set; } = null!;
        public DateTimeOffset? FechaRecepcion { get; set; }
        public string? IdMineralCondicion { get; set; }
        public int IdProveedor { get; set; }
        public string Placa { get; set; } = null!;
        public string PlacaCarreta { get; set; } = null!;
        public string? IdLoteChancadoEstado { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }

    }
}
