using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Balanza.LeyReferencial;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyReferencial
{
    public class UpdateLeyReferencialCommand : CommandBase<GetLeyReferencialDto>
    {
        public UpdateLeyReferencialCommand(UpdateLeyReferencialDto updateDto) => UpdateDto = updateDto;
        public UpdateLeyReferencialDto UpdateDto { get; set; }
    }
}
