using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class CreateLoteBalanzaCommandValidator : CommandValidatorBase<CreateLoteBalanzaCommand>
    {
        public CreateLoteBalanzaCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {

            });
        }
    }
}
