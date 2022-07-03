using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.ItemCheck;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.ItemCheck
{
    public class CreateItemCheckCommand : CommandBase<GetItemCheckDto>
    {
        public CreateItemCheckCommand(CreateItemCheckDto createDto) => CreateDto = createDto;
        public CreateItemCheckDto CreateDto { get; set; }
    }
}
