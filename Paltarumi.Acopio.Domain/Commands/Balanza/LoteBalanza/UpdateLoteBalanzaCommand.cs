using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCommand : CommandBase<GetLoteBalanzaDto>
    {
        public UpdateLoteBalanzaCommand(UpdateLoteBalanzaDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteBalanzaDto UpdateDto { get; set; }
    }
}
