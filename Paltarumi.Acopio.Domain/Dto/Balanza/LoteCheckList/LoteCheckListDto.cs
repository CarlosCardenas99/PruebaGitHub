
namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList
{
    public class LoteCheckListDto
    {
		public int IdLote { get; set; }
		public int IdCheckList { get; set; }
		public string NumeroDocumento { get; set; } = null!;
		public string Adjunto { get; set; }
		public int IdCheckListEstado { get; set; }
		public string Observacion { get; set; }
		public bool Habilitado { get; set; }
    }
}
