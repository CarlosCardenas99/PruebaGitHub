using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Vehiculo
{
    public class CreateVehiculoCommand : CommandBase<GetVehiculoDto>
    {
        public CreateVehiculoCommand(CreateVehiculoDto createDto) => CreateDto = createDto;
        public CreateVehiculoDto CreateDto { get; set; }
    }
}
