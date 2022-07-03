using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Concesion
{
    public class CreateConcesionCommandValidator : CommandValidatorBase<CreateConcesionCommand>
    {
        public CreateConcesionCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.Concesion.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.Concesion.FechaIngreso);
            });
        }
    }
}
