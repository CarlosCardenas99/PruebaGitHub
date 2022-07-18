using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class CreateOrUpdateLoteOperacionCommand : CommandBase
    {
        public CreateOrUpdateLoteOperacionCommand(CreateOrUpdateLoteOperacionDto loteOperacionDto)
            => LoteOperacionDto = loteOperacionDto;

        public CreateOrUpdateLoteOperacionDto LoteOperacionDto { get; set; }
    }
}
