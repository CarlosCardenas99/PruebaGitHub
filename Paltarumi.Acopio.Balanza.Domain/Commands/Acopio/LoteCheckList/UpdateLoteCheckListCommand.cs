using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteCheckList
{
    public class UpdateLoteCheckListCommand : CommandBase<GetLoteCheckListDto>
    {
        public UpdateLoteCheckListCommand(UpdateLoteCheckListDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteCheckListDto UpdateDto { get; set; }
    }
}
