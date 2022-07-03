using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Acopio.CheckList;

namespace Paltarumi.Acopio.Domain.Commands.Acopio.CheckList
{
    public class UpdateCheckListCommand : CommandBase<GetCheckListDto>
    {
        public UpdateCheckListCommand(UpdateCheckListDto updateDto) => UpdateDto = updateDto;
        public UpdateCheckListDto UpdateDto { get; set; }
    }
}
