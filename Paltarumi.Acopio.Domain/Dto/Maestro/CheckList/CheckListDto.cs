
namespace Paltarumi.Acopio.Domain.Dto.Maestro.CheckList
{
    public class CheckListDto
    {
		public int IdLoteBalanza { get; set; }
		public int IdItemCheck { get; set; }
		public string Observacion { get; set; }
		public string Adjunto { get; set; }
		public int IdCheckListEstado { get; set; }
		public bool Habilitado { get; set; }
    }
}
