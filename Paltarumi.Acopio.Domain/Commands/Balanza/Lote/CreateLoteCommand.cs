using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class CreateLoteCommand : CommandBase<GetLoteDto>
    {
        public CreateLoteCommand(CreateLoteDto createDto) => CreateDto = createDto;
        public CreateLoteDto CreateDto { get; set; }
    }
}
