using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Proveedor
{
    public class UpdateProveedorCommand : CommandBase<GetProveedorDto>
    {
        public UpdateProveedorCommand(UpdateProveedorDto updateDto) => UpdateDto = updateDto;
        public UpdateProveedorDto UpdateDto { get; set; }
    }
}
