namespace Paltarumi.Acopio.Domain.Dto.Maestro.CheckList
{
    public class GetCheckListDto : CheckListDto
    {
        public int IdCheckList { get; set; }
        public bool Activo { get; set; }
    }
}
