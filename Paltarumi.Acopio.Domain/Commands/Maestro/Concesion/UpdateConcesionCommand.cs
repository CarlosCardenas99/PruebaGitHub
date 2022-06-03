using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Concesion
{
    public class UpdateConcesionCommand : CommandBase<GetConcesionDto>
    {
        public UpdateConcesionCommand(UpdateConcesionDto updateDto) => UpdateDto = updateDto;
        public UpdateConcesionDto UpdateDto { get; set; }
    }
}
