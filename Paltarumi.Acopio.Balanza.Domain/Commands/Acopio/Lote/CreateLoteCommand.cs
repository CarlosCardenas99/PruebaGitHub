using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Lote;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Lote
{
    public class CreateLoteCommand : CommandBase<GetLoteDto>
    {
        public CreateLoteCommand(CreateLoteDto createDto) => CreateDto = createDto;
        public CreateLoteDto CreateDto { get; set; }
    }
}
