using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.DuenoMuestra
{
    public class CreateDuenoMuestraCommand : CommandBase<GetDuenoMuestraDto>
    {
        public CreateDuenoMuestraCommand(CreateDuenoMuestraDto createDto) => CreateDto = createDto;
        public CreateDuenoMuestraDto CreateDto { get; set; }
    }
}
