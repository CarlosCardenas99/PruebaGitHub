using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyReferencial
{
    public class CreateLeyReferencialCommand : CommandBase<GetLeyReferencialDto>
    {
        public CreateLeyReferencialCommand(CreateLeyReferencialDto createDto) => CreateDto = createDto;
        public CreateLeyReferencialDto CreateDto { get; set; }
    }
}
