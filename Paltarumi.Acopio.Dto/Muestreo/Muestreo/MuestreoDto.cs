
namespace Paltarumi.Acopio.Dto.Muestreo.Muestreo
{
    public class MuestreoDto
    {
		public int IdTurno { get; set; }
		public string? UserNameSupervisor { get; set; }
		public DateTimeOffset FechaMuestreo { get; set; }
		public string? CodigoLote { get; set; }
		public int? IdCancha { get; set; }
		public string? IdProveedor { get; set; }
		public int? IdDuenoMuestra { get; set; }
		public bool? LlevaGrueso { get; set; }
		public Single Tmh { get; set; }
		public int? IdMuestraCondicion { get; set; }
		public int? IdMuestraEstado { get; set; }
		public string? UserNameCreate { get; set; }
		public DateTimeOffset CreateDate { get; set; }
		public string? UserNameUpdate { get; set; }
		public DateTimeOffset UpdateDate { get; set; }
    }
}
