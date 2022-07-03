
namespace Paltarumi.Acopio.Dto.Chancado.Mapa
{
    public class MapaDto
    {
		public int? IdMapaPadre { get; set; }
		public int IdLoteChancado { get; set; }
		public string? Tipo { get; set; }
		public string? Numero { get; set; }
		public int? IdCancha { get; set; }
		public int? UbicacionX { get; set; }
		public int? UbicacionY { get; set; }
		public Single Tms { get; set; }
		public int IdEstado { get; set; }
		public int? IdChancadoCondicion { get; set; }
		public string? UserNameCreate { get; set; }
		public DateTimeOffset CreateDate { get; set; }
		public string? UserNameUpdate { get; set; }
		public DateTimeOffset UpdateDate { get; set; }
    }
}
