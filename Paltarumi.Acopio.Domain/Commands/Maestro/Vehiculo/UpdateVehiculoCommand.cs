using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo
{
    public class UpdateVehiculoCommand : CommandBase<GetVehiculoDto>
    {
        public UpdateVehiculoCommand(UpdateVehiculoDto updateDto) => UpdateDto = updateDto;
        public UpdateVehiculoDto UpdateDto { get; set; }
    }
}
