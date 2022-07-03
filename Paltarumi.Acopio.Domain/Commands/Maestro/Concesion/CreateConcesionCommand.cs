using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Concesion
{
    public class CreateConcesionCommand : CommandBase<GetConcesionDto>
    {
        public CreateConcesionCommand(CreateConcesionDto createDto) => CreateDto = createDto;
        public CreateConcesionDto CreateDto { get; set; }
    }
}
