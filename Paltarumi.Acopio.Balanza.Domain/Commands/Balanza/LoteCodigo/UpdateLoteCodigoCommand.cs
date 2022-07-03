using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class UpdateLoteCodigoCommand : CommandBase<GetLoteCodigoDto>
    {
        public UpdateLoteCodigoCommand(UpdateLoteCodigoDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteCodigoDto UpdateDto { get; set; }
    }
}
