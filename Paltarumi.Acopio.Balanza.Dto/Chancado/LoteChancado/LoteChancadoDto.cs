
namespace Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado
{
    public class LoteChancadoDto
    {
        public string? CodigoLote { get; set; }
        public DateTimeOffset FechaRecepcion { get; set; }
        public int? IdMineralCondicion { get; set; }
        public string? IdProveedor { get; set; }
        public string? Placa { get; set; }
        public string? PlacaCarreta { get; set; }
        public string? UserNameCreate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
    }
}
