using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class CreateConductorCommandValidator : CommandValidatorBase<CreateConductorCommand>
    {
        public CreateConductorCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                RequiredString(x => x.CreateDto.RazonSocial, Resources.Maestro.Conductor.RazonSocial, 3, 100);
                RequiredString(x => x.CreateDto.CodigoTipoDocumento, Resources.Maestro.Conductor.CodigoTipoDocumento, 2, 2);
                RequiredString(x => x.CreateDto.Numero, Resources.Maestro.Conductor.Numero, 8, 20);
                RequiredString(x => x.CreateDto.Licencia, Resources.Maestro.Conductor.Licencia, 8, 20);
            });
        }
    }
}
