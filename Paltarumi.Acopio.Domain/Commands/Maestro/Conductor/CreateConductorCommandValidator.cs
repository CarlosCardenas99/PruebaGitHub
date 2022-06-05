using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class CreateConductorCommandValidator : CommandValidatorBase<CreateConductorCommand>
    {
        public CreateConductorCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.Conductor.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.Conductor.FechaIngreso);
            });
        }
    }
}
