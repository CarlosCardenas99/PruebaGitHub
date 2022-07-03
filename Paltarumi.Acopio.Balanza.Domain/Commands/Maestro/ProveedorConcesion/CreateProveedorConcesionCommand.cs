using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.ProveedorConcesion
{
    public class CreateProveedorConcesionCommand : CommandBase<GetProveedorConcesionDto>
    {
        public CreateProveedorConcesionCommand(CreateProveedorConcesionDto createDto) => CreateDto = createDto;
        public CreateProveedorConcesionDto CreateDto { get; set; }
    }
}
