using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Concesion
{
    public class UpdateConcesionCommand : CommandBase<GetConcesionDto>
    {
        public UpdateConcesionCommand(UpdateConcesionDto updateDto) => UpdateDto = updateDto;
        public UpdateConcesionDto UpdateDto { get; set; }
    }
}
