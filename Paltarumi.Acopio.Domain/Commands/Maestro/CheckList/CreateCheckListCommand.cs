using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.CheckList
{
    public class CreateCheckListCommand : CommandBase<GetCheckListDto>
    {
        public CreateCheckListCommand(CreateCheckListDto createDto) => CreateDto = createDto;
        public CreateCheckListDto CreateDto { get; set; }
    }
}
