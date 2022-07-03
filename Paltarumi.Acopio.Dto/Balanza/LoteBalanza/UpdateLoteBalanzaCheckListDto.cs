using Paltarumi.Acopio.Dto.Acopio.LoteCheckList;

namespace Paltarumi.Acopio.Dto.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCheckListDto
    {
        public int IdLoteBalanza { get; set; }
        public IEnumerable<UpdateLoteCheckListDto>? CheckListDetails { get; set; }
    }
}
