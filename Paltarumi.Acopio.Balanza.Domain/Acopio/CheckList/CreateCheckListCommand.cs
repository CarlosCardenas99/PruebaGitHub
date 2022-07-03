using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.CheckList;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.CheckList
{
    public class CreateCheckListCommand : CommandBase<GetCheckListDto>
    {
        public CreateCheckListCommand(CreateCheckListDto createDto) => CreateDto = createDto;
        public CreateCheckListDto CreateDto { get; set; }
    }
}
