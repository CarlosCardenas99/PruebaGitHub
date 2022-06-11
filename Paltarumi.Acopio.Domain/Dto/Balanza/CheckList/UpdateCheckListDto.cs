namespace Paltarumi.Acopio.Domain.Dto.Balanza.CheckList
{
    public class UpdateCheckListDto : CheckListDto
    {
        public int IdCheckList { get; set; }
        public bool Activo { get; set; }
    }
}
