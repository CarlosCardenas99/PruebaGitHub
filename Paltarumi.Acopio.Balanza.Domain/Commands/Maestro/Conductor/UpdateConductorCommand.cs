using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Conductor
{
    public class UpdateConductorCommand : CommandBase<GetConductorDto>
    {
        public UpdateConductorCommand(UpdateConductorDto updateDto) => UpdateDto = updateDto;
        public UpdateConductorDto UpdateDto { get; set; }
    }
}
