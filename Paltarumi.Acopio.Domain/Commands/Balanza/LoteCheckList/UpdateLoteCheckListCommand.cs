using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCheckList
{
    public class UpdateLoteCheckListCommand : CommandBase<GetLoteCheckListDto>
    {
        public UpdateLoteCheckListCommand(UpdateLoteCheckListDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteCheckListDto UpdateDto { get; set; }
    }
}
