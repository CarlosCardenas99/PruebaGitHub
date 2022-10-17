
namespace Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa
{
    public class MapaDto
    {
        public int? IdMapaPadre { get; set; }
        public int IdLoteChancado { get; set; }
        public string? IdLoteChancadoGrupo { get; set; }
        public string? Numero { get; set; }
        public string? IdCancha { get; set; }
        public int? UbicacionX { get; set; }
        public int? UbicacionY { get; set; }
        public decimal Tmh { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
        public string? UserNameUpdate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
    }
}
