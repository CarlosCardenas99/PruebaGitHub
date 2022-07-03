using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Acopio.CheckList;

namespace Paltarumi.Acopio.Domain.Commands.Acopio.CheckList
{
    public class CreateCheckListCommand : CommandBase<GetCheckListDto>
    {
        public CreateCheckListCommand(CreateCheckListDto createDto) => CreateDto = createDto;
        public CreateCheckListDto CreateDto { get; set; }
    }
}
