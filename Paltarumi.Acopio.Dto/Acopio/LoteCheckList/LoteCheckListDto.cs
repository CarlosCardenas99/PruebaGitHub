
namespace Paltarumi.Acopio.Dto.Acopio.LoteCheckList
{
    public class LoteCheckListDto
    {
		public int IdLote { get; set; }
		public int IdCheckListEstado { get; set; }
		public bool Habilitado { get; set; }
		public string? Observacion { get; set; }
		public string? Adjunto { get; set; }
		public string? UserNameCreate { get; set; }
		public DateTimeOffset CreateDate { get; set; }
    }
}
