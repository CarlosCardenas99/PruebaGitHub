using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Proveedor
{
    public class CreateProveedorCommandValidator : CommandValidatorBase<CreateProveedorCommand>
    {
        public CreateProveedorCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.Proveedor.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.Proveedor.FechaIngreso);
            });
        }
    }
}
