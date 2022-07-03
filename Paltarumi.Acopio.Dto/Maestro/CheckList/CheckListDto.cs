
namespace Paltarumi.Acopio.Dto.Maestro.CheckList
{
    public class CheckListDto
    {
        public int IdLoteBalanza { get; set; }
        public int IdItemCheck { get; set; }
        public string Adjunto { get; set; } = null!;
        public string ObservacionBalanza { get; set; } = null!;
        public int IdCheckListEstadoBalanza { get; set; }
        public bool HabilitadoBalanza { get; set; }
        public string ObservacionComercial { get; set; } = null!;
        public int IdCheckListEstadoComercial { get; set; }
        public bool HabilitadoComercial { get; set; }
    }
}
