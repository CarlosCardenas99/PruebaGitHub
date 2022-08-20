using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class UpdateLoteMuestreoCommandValidator : CommandValidatorBase<UpdateLoteMuestreoCommand>
    {
        public UpdateLoteMuestreoCommandValidator()
        {
            RequiredInformation(x => x.UpdateDto);
        }
    }
}
