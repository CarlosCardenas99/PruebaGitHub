using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ProveedorConcesion
{
    public class CreateProveedorConcesionCommand : CommandBase<GetProveedorConcesionDto>
    {
        public CreateProveedorConcesionCommand(CreateProveedorConcesionDto createDto) => CreateDto = createDto;
        public CreateProveedorConcesionDto CreateDto { get; set; }
    }
}
