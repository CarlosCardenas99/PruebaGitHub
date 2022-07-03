using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Maestro
{
    public class CreateMaestroCommandValidator : CommandValidatorBase<CreateMaestroCommand>
    {
        public CreateMaestroCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.Maestro.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.Maestro.FechaIngreso);
            });
        }
    }
}
