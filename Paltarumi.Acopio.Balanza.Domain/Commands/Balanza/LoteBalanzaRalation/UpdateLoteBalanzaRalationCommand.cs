using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class UpdateLoteBalanzaRalationCommand : CommandBase<GetLoteBalanzaRalationDto>
    {
        public UpdateLoteBalanzaRalationCommand(UpdateLoteBalanzaRalationDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteBalanzaRalationDto UpdateDto { get; set; }
    }
}
