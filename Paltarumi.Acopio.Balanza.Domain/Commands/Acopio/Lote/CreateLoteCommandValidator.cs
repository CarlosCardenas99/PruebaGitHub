using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Lote
{
    public class CreateLoteCommandValidator : CommandValidatorBase<CreateLoteCommand>
    {
        public CreateLoteCommandValidator()
        {
            RequiredInformation(x => x.CreateDto);
        }
    }
}
