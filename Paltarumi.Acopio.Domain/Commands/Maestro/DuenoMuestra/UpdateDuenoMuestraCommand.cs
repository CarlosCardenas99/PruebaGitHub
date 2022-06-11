using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.DuenoMuestra
{
    public class UpdateDuenoMuestraCommand : CommandBase<GetDuenoMuestraDto>
    {
        public UpdateDuenoMuestraCommand(UpdateDuenoMuestraDto updateDto) => UpdateDto = updateDto;
        public UpdateDuenoMuestraDto UpdateDto { get; set; }
    }
}
