using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class CreateLoteBalanzaRalationCommandValidator : CommandValidatorBase<CreateLoteBalanzaRalationCommand>
    {
        public CreateLoteBalanzaRalationCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.LoteBalanzaRalation.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.LoteBalanzaRalation.FechaIngreso);
            });
        }
    }
}
