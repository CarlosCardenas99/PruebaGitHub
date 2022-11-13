using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class CreateLoteBalanzaRalationCommand : CommandBase<GetLoteBalanzaRalationDto>
    {
        public CreateLoteBalanzaRalationCommand(CreateLoteBalanzaRalationDto createDto) => CreateDto = createDto;
        public CreateLoteBalanzaRalationDto CreateDto { get; set; }
    }
}
