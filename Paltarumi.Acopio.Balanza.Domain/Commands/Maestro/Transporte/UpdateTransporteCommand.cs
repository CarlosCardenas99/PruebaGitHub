using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Transporte
{
    public class UpdateTransporteCommand : CommandBase<GetTransporteDto>
    {
        public UpdateTransporteCommand(UpdateTransporteDto updateDto) => UpdateDto = updateDto;
        public UpdateTransporteDto UpdateDto { get; set; }
    }
}
