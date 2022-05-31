using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Maestro
{
    public class UpdateMaestroCommand : CommandBase<GetMaestroDto>
    {
        public UpdateMaestroCommand(UpdateMaestroDto updateDto) => UpdateDto = updateDto;
        public UpdateMaestroDto UpdateDto { get; set; }
    }
}
