using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Transporte
{
    public class CreateTransporteCommandValidator : CommandValidatorBase<CreateTransporteCommand>
    {
        public CreateTransporteCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.Transporte.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.Transporte.FechaIngreso);
            });
        }
    }
}
