using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Maestro
{
    public class UpdateMaestroCommand : CommandBase<GetMaestroDto>
    {
        public UpdateMaestroCommand(UpdateMaestroDto updateDto) => UpdateDto = updateDto;
        public UpdateMaestroDto UpdateDto { get; set; }
    }
}
