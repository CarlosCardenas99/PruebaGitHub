using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.CheckList;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.CheckList
{
    public class UpdateCheckListCommand : CommandBase<GetCheckListDto>
    {
        public UpdateCheckListCommand(UpdateCheckListDto updateDto) => UpdateDto = updateDto;
        public UpdateCheckListDto UpdateDto { get; set; }
    }
}
