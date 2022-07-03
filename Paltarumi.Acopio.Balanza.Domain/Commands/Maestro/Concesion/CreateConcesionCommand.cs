using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Concesion
{
    public class CreateConcesionCommand : CommandBase<GetConcesionDto>
    {
        public CreateConcesionCommand(CreateConcesionDto createDto) => CreateDto = createDto;
        public CreateConcesionDto CreateDto { get; set; }
    }
}
