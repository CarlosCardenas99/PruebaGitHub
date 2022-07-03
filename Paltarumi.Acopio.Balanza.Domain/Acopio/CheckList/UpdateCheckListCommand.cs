using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.CheckList;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.CheckList
{
    public class UpdateCheckListCommand : CommandBase<GetCheckListDto>
    {
        public UpdateCheckListCommand(UpdateCheckListDto updateDto) => UpdateDto = updateDto;
        public UpdateCheckListDto UpdateDto { get; set; }
    }
}
