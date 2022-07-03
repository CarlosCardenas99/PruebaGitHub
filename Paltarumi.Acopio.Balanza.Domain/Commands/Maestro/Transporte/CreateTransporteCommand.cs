using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Transporte
{
    public class CreateTransporteCommand : CommandBase<GetTransporteDto>
    {
        public CreateTransporteCommand(CreateTransporteDto createDto) => CreateDto = createDto;
        public CreateTransporteDto CreateDto { get; set; }
    }
}
