using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class CreateConductorCommand : CommandBase<GetConductorDto>
    {
        public CreateConductorCommand(CreateConductorDto createDto) => CreateDto = createDto;
        public CreateConductorDto CreateDto { get; set; }
    }
}
