namespace Paltarumi.Acopio.Dto.Acopio.LoteCheckList
{
    public class LoteCheckListDto
    {
        public int IdLote { get; set; }
        public int IdCheckListEstado { get; set; }
        public bool Habilitado { get; set; }
        public string Observacion { get; set; } = null!;
        public string Adjunto { get; set; } = null!;
    }
}
