using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa
{
    public class UpdateMapaEstadoCommand : CommandBase<GetMapaDto>
    {
        public UpdateMapaEstadoCommand(UpdateMapaEstadoDto updateDto) => UpdateDto = updateDto;
        public UpdateMapaEstadoDto UpdateDto { get; set; }
    }
}
