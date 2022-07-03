using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Proveedor
{
    public class CreateProveedorCommand : CommandBase<GetProveedorDto>
    {
        public CreateProveedorCommand(CreateProveedorDto createDto) => CreateDto = createDto;
        public CreateProveedorDto CreateDto { get; set; }
    }
}
