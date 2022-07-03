using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LeyReferencial
{
    public class UpdateLeyReferencialCommand : CommandBase<GetLeyReferencialDto>
    {
        public UpdateLeyReferencialCommand(UpdateLeyReferencialDto updateDto) => UpdateDto = updateDto;
        public UpdateLeyReferencialDto UpdateDto { get; set; }
    }
}
