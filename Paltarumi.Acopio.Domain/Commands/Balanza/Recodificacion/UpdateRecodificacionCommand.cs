using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Recodificacion
{
    public class UpdateRecodificacionCommand : CommandBase<GetRecodificacionDto>
    {
        public UpdateRecodificacionCommand(UpdateRecodificacionDto updateDto) => UpdateDto = updateDto;
        public UpdateRecodificacionDto UpdateDto { get; set; }
    }
}
