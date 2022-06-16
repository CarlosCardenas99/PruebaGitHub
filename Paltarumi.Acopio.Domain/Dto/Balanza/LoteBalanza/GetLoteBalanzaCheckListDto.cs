using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza
{
    public class GetLoteBalanzaCheckListDto
    {
        public int IdLoteBalanza { get; set; }
        public int PorcentajeCheckList { get; set; }
        public IEnumerable<GetCheckListDto>? CheckListDetails { get; set; }
    }
}
