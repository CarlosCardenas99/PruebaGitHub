using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Dto;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateTmsLoteBalanzaCommand : CommandBase
    {
        public UpdateTmsLoteBalanzaCommand(UpdateTmsLoteBalanzaDto updateDto) => UpdateDto = updateDto;
        public UpdateTmsLoteBalanzaDto UpdateDto { get; set; }
    }
}
