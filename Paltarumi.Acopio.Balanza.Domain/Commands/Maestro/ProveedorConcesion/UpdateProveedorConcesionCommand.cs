using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.ProveedorConcesion
{
    public class UpdateProveedorConcesionCommand : CommandBase<GetProveedorConcesionDto>
    {
        public UpdateProveedorConcesionCommand(UpdateProveedorConcesionDto updateDto) => UpdateDto = updateDto;
        public UpdateProveedorConcesionDto UpdateDto { get; set; }
    }
}
