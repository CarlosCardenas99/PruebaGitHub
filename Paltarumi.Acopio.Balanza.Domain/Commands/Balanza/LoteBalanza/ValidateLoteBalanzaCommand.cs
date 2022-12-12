using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class ValidateLoteBalanzaCommand : CommandBase
    {
        public ValidateLoteBalanzaCommand(ValidateLoteBalanzaDto validateDto) => ValidateDto = validateDto;
        public ValidateLoteBalanzaDto ValidateDto { get; set; }
    }
}
