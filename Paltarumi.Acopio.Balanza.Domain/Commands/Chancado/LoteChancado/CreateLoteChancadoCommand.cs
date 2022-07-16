using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class CreateLoteChancadoCommand : CommandBase<GetLoteChancadoDto>
    {
        public CreateLoteChancadoCommand(CreateLoteChancadoDto createDto) => CreateDto = createDto;
        public CreateLoteChancadoDto CreateDto { get; set; }
    }
}
