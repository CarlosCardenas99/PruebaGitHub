using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Maestro.ItemCheck;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ItemCheck
{
    public class UpdateItemCheckCommand : CommandBase<GetItemCheckDto>
    {
        public UpdateItemCheckCommand(UpdateItemCheckDto updateDto) => UpdateDto = updateDto;
        public UpdateItemCheckDto UpdateDto { get; set; }
    }
}
