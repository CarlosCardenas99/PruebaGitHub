namespace Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList
{
    public class UpdateLoteCheckListDto
    {
        public int IdLoteCheckList { get; set; }
        public int IdLoteBalanza { get; set; }
        public int IdItemCheck { get; set; }
        public bool Habilitado { get; set; }
        public bool Verificado { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
