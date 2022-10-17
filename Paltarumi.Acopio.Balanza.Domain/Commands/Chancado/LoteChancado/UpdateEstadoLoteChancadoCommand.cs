// TO DO : PRUEBA
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class UpdateEstadoLoteChancadoCommand : CommandBase<GetLoteChancadoDto>
    {
        public UpdateEstadoLoteChancadoCommand(UpdateEstadoLoteChancadoDto updateDto) => UpdateDto = updateDto;
        public UpdateEstadoLoteChancadoDto UpdateDto { get; set; }
    }
}
