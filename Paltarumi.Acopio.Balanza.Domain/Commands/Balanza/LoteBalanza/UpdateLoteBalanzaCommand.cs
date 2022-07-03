using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCommand : CommandBase<GetLoteBalanzaDto>
    {
        public UpdateLoteBalanzaCommand(UpdateLoteBalanzaDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteBalanzaDto UpdateDto { get; set; }
    }
}
