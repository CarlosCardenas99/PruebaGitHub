using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Maestro
{
    public class CreateMaestroCommand : CommandBase<GetMaestroDto>
    {
        public CreateMaestroCommand(CreateMaestroDto createDto) => CreateDto = createDto;
        public CreateMaestroDto CreateDto { get; set; }
    }
}
