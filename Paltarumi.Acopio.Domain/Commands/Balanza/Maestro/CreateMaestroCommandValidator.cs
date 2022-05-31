using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Maestro
{
    public class CreateMaestroCommandValidator : CommandValidatorBase<CreateMaestroCommand>
    {
        public CreateMaestroCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.Maestro.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.Maestro.FechaIngreso);
            });
        }
    }
}
