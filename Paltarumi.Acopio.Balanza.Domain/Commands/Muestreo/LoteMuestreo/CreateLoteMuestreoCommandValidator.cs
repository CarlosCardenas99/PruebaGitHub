using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class CreateLoteMuestreoCommandValidator : CommandValidatorBase<CreateLoteMuestreoCommand>
    {
        public CreateLoteMuestreoCommandValidator()
        {
            RequiredInformation(x => x.CreateDto);
        }
    }
}
