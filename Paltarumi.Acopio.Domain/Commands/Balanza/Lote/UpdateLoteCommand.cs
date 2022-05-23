using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class UpdateLoteCommand : CommandBase<GetLoteDto>
    {
        public UpdateLoteCommand(UpdateLoteDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteDto UpdateDto { get; set; }
    }
}
