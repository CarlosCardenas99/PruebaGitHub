using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LeyReferencial
{
    public class CreateLeyReferencialCommandValidator : CommandValidatorBase<CreateLeyReferencialCommand>
    {
        public CreateLeyReferencialCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.LeyReferencial.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.LeyReferencial.FechaIngreso);
            });
        }
    }
}
