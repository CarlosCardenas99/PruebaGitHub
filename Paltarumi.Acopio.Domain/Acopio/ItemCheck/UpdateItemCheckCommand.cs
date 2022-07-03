using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Acopio.ItemCheck;

namespace Paltarumi.Acopio.Domain.Commands.Acopio.ItemCheck
{
    public class UpdateItemCheckCommand : CommandBase<GetItemCheckDto>
    {
        public UpdateItemCheckCommand(UpdateItemCheckDto updateDto) => UpdateDto = updateDto;
        public UpdateItemCheckDto UpdateDto { get; set; }
    }
}
