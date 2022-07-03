using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Maestro
{
    public class UpdateMaestroCommand : CommandBase<GetMaestroDto>
    {
        public UpdateMaestroCommand(UpdateMaestroDto updateDto) => UpdateDto = updateDto;
        public UpdateMaestroDto UpdateDto { get; set; }
    }
}
