using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Liquidacion.LoteLiquidacion
{
    public class CreateLoteLiquidacionCommandValidator : CommandValidatorBase<CreateLoteLiquidacionCommand>
    {
        public CreateLoteLiquidacionCommandValidator()
        {
            RequiredInformation(x => x.CreateDto);
        }
    }
}
