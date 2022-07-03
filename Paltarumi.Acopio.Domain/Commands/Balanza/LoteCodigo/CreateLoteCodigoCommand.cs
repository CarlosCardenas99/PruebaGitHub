using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteCodigo;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCodigo
{
    public class CreateLoteCodigoCommand : CommandBase<GetLoteCodigoDto>
    {
        public CreateLoteCodigoCommand(CreateLoteCodigoDto createDto) => CreateDto = createDto;
        public CreateLoteCodigoDto CreateDto { get; set; }
    }
}
