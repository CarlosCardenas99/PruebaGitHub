using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class UpdateLoteOperacionStatusCommand : CommandBase
    {
        public UpdateLoteOperacionStatusCommand(UpdateLoteOperacionStatusDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteOperacionStatusDto UpdateDto { get; set; }
    }
}
