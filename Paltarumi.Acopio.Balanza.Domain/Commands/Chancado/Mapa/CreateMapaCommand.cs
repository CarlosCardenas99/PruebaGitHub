using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa
{
    public class CreateMapaCommand : CommandBase<GetMapaDto>
    {
        public CreateMapaCommand(CreateMapaDto createDto) => CreateDto = createDto;
        public CreateMapaDto CreateDto { get; set; }
    }
}
