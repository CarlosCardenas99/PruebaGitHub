using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo
{
    public class CreateVehiculoCommand : CommandBase<GetVehiculoDto>
    {
        public CreateVehiculoCommand(CreateVehiculoDto createDto) => CreateDto = createDto;
        public CreateVehiculoDto CreateDto { get; set; }
    }
}
