using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Proveedor
{
    public class UpdateProveedorCommand : CommandBase<GetProveedorDto>
    {
        public UpdateProveedorCommand(UpdateProveedorDto updateDto) => UpdateDto = updateDto;
        public UpdateProveedorDto UpdateDto { get; set; }
    }
}
