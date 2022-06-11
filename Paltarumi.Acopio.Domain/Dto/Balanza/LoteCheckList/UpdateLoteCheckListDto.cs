namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList
{
    public class UpdateLoteCheckListDto : LoteCheckListDto
    {
        public int IdLoteCheckList { get; set; }
        public bool Activo { get; set; }
    }
}
