using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class CreateLoteOperacionCommand : CommandBase<GetLoteOperacionDto>
    {
        public CreateLoteOperacionCommand(CreateLoteOperacionDto createDto) => CreateDto = createDto;
        public CreateLoteOperacionDto CreateDto { get; set; }
    }
}
