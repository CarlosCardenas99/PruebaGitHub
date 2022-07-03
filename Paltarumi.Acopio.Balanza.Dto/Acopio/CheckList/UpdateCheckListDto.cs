namespace Paltarumi.Acopio.Dto.CheckList
{
    public class UpdateCheckListDto : CheckListDto
    {
        public int IdCheckList { get; set; }
        public bool Activo { get; set; }
    }
}
