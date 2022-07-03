using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Maestro
{
    public class CreateMaestroCommand : CommandBase<GetMaestroDto>
    {
        public CreateMaestroCommand(CreateMaestroDto createDto) => CreateDto = createDto;
        public CreateMaestroDto CreateDto { get; set; }
    }
}
