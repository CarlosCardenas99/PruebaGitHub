using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyesReferenciales
{
    public class CreateLeyesReferencialesCommandValidator : CommandValidatorBase<CreateLeyesReferencialesCommand>
    {
        public CreateLeyesReferencialesCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.LeyesReferenciales.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.LeyesReferenciales.FechaIngreso);
            });
        }
    }
}
