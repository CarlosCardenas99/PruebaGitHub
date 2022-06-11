using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCodigo
{
    public class UpdateLoteCodigoCommand : CommandBase<GetLoteCodigoDto>
    {
        public UpdateLoteCodigoCommand(UpdateLoteCodigoDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteCodigoDto UpdateDto { get; set; }
    }
}
