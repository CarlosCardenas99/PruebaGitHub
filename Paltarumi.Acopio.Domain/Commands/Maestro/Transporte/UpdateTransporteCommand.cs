using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Transporte
{
    public class UpdateTransporteCommand : CommandBase<GetTransporteDto>
    {
        public UpdateTransporteCommand(UpdateTransporteDto updateDto) => UpdateDto = updateDto;
        public UpdateTransporteDto UpdateDto { get; set; }
    }
}
