using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Conductor
{
    public class CreateConductorCommand : CommandBase<GetConductorDto>
    {
        public CreateConductorCommand(CreateConductorDto createDto) => CreateDto = createDto;
        public CreateConductorDto CreateDto { get; set; }
    }
}
