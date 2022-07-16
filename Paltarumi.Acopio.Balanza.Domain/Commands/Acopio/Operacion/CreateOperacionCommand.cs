using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Operacion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Operacion
{
    public class CreateOperacionCommand : CommandBase<GetOperacionDto>
    {
        public CreateOperacionCommand(CreateOperacionDto createDto) => CreateDto = createDto;
        public CreateOperacionDto CreateDto { get; set; }
    }
}
