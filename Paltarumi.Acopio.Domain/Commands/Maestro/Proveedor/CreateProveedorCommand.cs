using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Proveedor
{
    public class CreateProveedorCommand : CommandBase<GetProveedorDto>
    {
        public CreateProveedorCommand(CreateProveedorDto createDto) => CreateDto = createDto;
        public CreateProveedorDto CreateDto { get; set; }
    }
}
