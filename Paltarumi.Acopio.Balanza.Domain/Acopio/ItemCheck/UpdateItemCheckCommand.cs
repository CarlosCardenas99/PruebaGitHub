using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.ItemCheck;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.ItemCheck
{
    public class UpdateItemCheckCommand : CommandBase<GetItemCheckDto>
    {
        public UpdateItemCheckCommand(UpdateItemCheckDto updateDto) => UpdateDto = updateDto;
        public UpdateItemCheckDto UpdateDto { get; set; }
    }
}
