using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo
{
    public class CreateVehiculoCommandValidator : CommandValidatorBase<CreateVehiculoCommand>
    {
        public CreateVehiculoCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.Vehiculo.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.Vehiculo.FechaIngreso);
            });
        }
    }
}
