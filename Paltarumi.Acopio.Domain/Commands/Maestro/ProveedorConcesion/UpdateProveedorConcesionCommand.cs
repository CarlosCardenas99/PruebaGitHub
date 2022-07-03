using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Maestro.ProveedorConcesion;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ProveedorConcesion
{
    public class UpdateProveedorConcesionCommand : CommandBase<GetProveedorConcesionDto>
    {
        public UpdateProveedorConcesionCommand(UpdateProveedorConcesionDto updateDto) => UpdateDto = updateDto;
        public UpdateProveedorConcesionDto UpdateDto { get; set; }
    }
}
