using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class CreateLoteCodigoCommand : CommandBase<GetLoteCodigoDto>
    {
        public CreateLoteCodigoCommand(CreateLoteCodigoDto createDto) => CreateDto = createDto;
        public CreateLoteCodigoDto CreateDto { get; set; }
    }
}
