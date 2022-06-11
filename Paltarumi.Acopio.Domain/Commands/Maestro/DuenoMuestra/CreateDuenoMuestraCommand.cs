using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.DuenoMuestra
{
    public class CreateDuenoMuestraCommand : CommandBase<GetDuenoMuestraDto>
    {
        public CreateDuenoMuestraCommand(CreateDuenoMuestraDto createDto) => CreateDto = createDto;
        public CreateDuenoMuestraDto CreateDto { get; set; }
    }
}
