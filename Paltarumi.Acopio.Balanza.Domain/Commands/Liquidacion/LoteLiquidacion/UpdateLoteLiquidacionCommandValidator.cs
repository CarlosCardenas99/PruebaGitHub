using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Liquidacion.LoteLiquidacion
{
    public class UpdateLoteLiquidacionCommandValidator : CommandValidatorBase<UpdateLoteLiquidacionCommand>
    {
        public UpdateLoteLiquidacionCommandValidator()
        {
            RequiredInformation(x => x.UpdateDto);
        }
    }
}
