using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ProveedorConcesion
{
    public class CreateProveedorConcesionCommandValidator : CommandValidatorBase<CreateProveedorConcesionCommand>
    {
        public CreateProveedorConcesionCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.ProveedorConcesion.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.ProveedorConcesion.FechaIngreso);
            });
        }
    }
}
