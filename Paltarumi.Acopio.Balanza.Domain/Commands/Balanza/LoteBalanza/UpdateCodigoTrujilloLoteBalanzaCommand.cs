using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateCodigoTrujilloLoteBalanzaCommand : CommandBase<GetLoteBalanzaDto>
    {
        public UpdateCodigoTrujilloLoteBalanzaCommand(UpdateCodigoTrujilloLoteBalanzaDto updateDto) => UpdateDto = updateDto;
        public UpdateCodigoTrujilloLoteBalanzaDto UpdateDto { get; set; }
    }
}
