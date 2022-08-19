using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class CreateLoteCodigoMuestreoCommandValidator : CommandValidatorBase<CreateLoteCodigoMuestreoCommand>
    {
        public CreateLoteCodigoMuestreoCommandValidator()
        {
            RequiredInformation(x => x.CreateDto);
        }
    }
}
