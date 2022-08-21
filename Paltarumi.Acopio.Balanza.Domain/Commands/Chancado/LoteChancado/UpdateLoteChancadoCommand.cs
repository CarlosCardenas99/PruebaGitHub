using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class UpdateLoteChancadoCommand : CommandBase<GetLoteChancadoDto>
    {
        public UpdateLoteChancadoCommand(UpdateLoteChancadoDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteChancadoDto UpdateDto { get; set; }
    }
}
