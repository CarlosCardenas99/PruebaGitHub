using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class CreateLoteBalanzaCommand : CommandBase<GetLoteBalanzaDto>
    {
        public CreateLoteBalanzaCommand(CreateLoteBalanzaDto createDto) => CreateDto = createDto;
        public CreateLoteBalanzaDto CreateDto { get; set; }
    }
}
