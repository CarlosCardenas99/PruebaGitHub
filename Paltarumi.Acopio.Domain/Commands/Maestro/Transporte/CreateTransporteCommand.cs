using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Transporte
{
    public class CreateTransporteCommand : CommandBase<GetTransporteDto>
    {
        public CreateTransporteCommand(CreateTransporteDto createDto) => CreateDto = createDto;
        public CreateTransporteDto CreateDto { get; set; }
    }
}
