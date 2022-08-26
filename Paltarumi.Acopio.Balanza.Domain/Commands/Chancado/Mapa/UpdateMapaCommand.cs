using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa
{
    public class UpdateMapaCommand : CommandBase<GetMapaDto>
    {
        public UpdateMapaCommand(UpdateMapaDto updateDto) => UpdateDto = updateDto;
        public UpdateMapaDto UpdateDto { get; set; }
    }
}
