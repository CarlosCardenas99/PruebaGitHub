using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Liquidacion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Liquidacion.LoteLiquidacion
{
    public class CreateLoteLiquidacionCommand : CommandBase<GetLoteLiquidacionDto>
    {
        public CreateLoteLiquidacionCommand(CreateLoteLiquidacionDto createDto) => CreateDto = createDto;
        public CreateLoteLiquidacionDto CreateDto { get; set; }
    }
}
