using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class UpdateLoteOperacionCommand : CommandBase<GetLoteOperacionDto>
    {
        public UpdateLoteOperacionCommand(UpdateLoteOperacionDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteOperacionDto UpdateDto { get; set; }
    }
}
