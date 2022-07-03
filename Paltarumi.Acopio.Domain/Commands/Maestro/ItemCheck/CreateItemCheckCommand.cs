using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Maestro.ItemCheck;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ItemCheck
{
    public class CreateItemCheckCommand : CommandBase<GetItemCheckDto>
    {
        public CreateItemCheckCommand(CreateItemCheckDto createDto) => CreateDto = createDto;
        public CreateItemCheckDto CreateDto { get; set; }
    }
}
