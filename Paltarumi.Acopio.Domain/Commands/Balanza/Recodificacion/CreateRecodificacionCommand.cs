using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Recodificacion
{
    public class CreateRecodificacionCommand : CommandBase<GetRecodificacionDto>
    {
        public CreateRecodificacionCommand(CreateRecodificacionDto createDto) => CreateDto = createDto;
        public CreateRecodificacionDto CreateDto { get; set; }
    }
}
