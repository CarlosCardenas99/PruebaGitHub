using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Liquidacion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Liquidacion.LoteLiquidaciones
{
    public class UpdateLoteLiquidacionCommand : CommandBase<GetLoteLiquidacionDto>
    {
        public UpdateLoteLiquidacionCommand(UpdateLoteLiquidacionDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteLiquidacionDto UpdateDto { get; set; }
    }
}
