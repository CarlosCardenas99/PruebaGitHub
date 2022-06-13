using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class CreateLoteBalanzaCommand : CommandBase<GetLoteBalanzaDto>
    {
        public CreateLoteBalanzaCommand(CreateLoteBalanzaDto createDto) => CreateDto = createDto;
        public CreateLoteBalanzaDto CreateDto { get; set; }
    }
}
