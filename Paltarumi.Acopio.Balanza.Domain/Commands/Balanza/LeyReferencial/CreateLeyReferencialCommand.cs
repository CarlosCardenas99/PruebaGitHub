using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LeyReferencial
{
    public class CreateLeyReferencialCommand : CommandBase<GetLeyReferencialDto>
    {
        public CreateLeyReferencialCommand(CreateLeyReferencialDto createDto) => CreateDto = createDto;
        public CreateLeyReferencialDto CreateDto { get; set; }
    }
}
