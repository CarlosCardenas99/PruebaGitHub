using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Vehiculo
{
    public class UpdateVehiculoCommand : CommandBase<GetVehiculoDto>
    {
        public UpdateVehiculoCommand(UpdateVehiculoDto updateDto) => UpdateDto = updateDto;
        public UpdateVehiculoDto UpdateDto { get; set; }
    }
}
