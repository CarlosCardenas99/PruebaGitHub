using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.DuenoMuestra
{
    public class UpdateDuenoMuestraCommand : CommandBase<GetDuenoMuestraDto>
    {
        public UpdateDuenoMuestraCommand(UpdateDuenoMuestraDto updateDto) => UpdateDto = updateDto;
        public UpdateDuenoMuestraDto UpdateDto { get; set; }
    }
}
