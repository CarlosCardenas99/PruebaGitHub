using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Acopio.ItemCheck;

namespace Paltarumi.Acopio.Domain.Commands.Acopio.ItemCheck
{
    public class CreateItemCheckCommand : CommandBase<GetItemCheckDto>
    {
        public CreateItemCheckCommand(CreateItemCheckDto createDto) => CreateDto = createDto;
        public CreateItemCheckDto CreateDto { get; set; }
    }
}
