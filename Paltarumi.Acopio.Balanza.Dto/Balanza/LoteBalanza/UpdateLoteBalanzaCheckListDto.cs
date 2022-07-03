using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;

namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class UpdateLoteBalanzaCheckListDto
    {
        public int IdLoteBalanza { get; set; }
        public IEnumerable<UpdateLoteCheckListDto>? CheckListDetails { get; set; }
    }
}
