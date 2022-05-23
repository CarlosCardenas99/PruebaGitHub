using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class UpdateConductorCommand : CommandBase<GetConductorDto>
    {
        public UpdateConductorCommand(UpdateConductorDto updateDto) => UpdateDto = updateDto;
        public UpdateConductorDto UpdateDto { get; set; }
    }
}
