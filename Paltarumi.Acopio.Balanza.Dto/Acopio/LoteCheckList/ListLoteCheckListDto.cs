
namespace Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList
{
    public class ListLoteCheckListDto: LoteCheckListDto
    {
        public int IdLoteCheckList { get; set; }
        public string? NombreItemCheck { get; set; }
        public string? NombreModulo { get; set; }
        public bool Activo { get; set; }
    }
}
