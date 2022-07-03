namespace Paltarumi.Acopio.Dto.Maestro.CheckList
{
    public class UpdateCheckListDto : CheckListDto
    {
        public int IdCheckList { get; set; }
        public bool Activo { get; set; }
    }
}
