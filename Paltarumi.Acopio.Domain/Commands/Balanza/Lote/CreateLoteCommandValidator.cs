using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class CreateLoteCommandValidator : CommandValidatorBase<CreateLoteCommand>
    {
        public CreateLoteCommandValidator()
        {
            RequiredInformation(x => x.CreateDto);
        }
    }
}
