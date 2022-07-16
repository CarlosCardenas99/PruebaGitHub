using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Operacion
{
    public class CreateOperacionCommandValidator : CommandValidatorBase<CreateOperacionCommand>
    {
        public CreateOperacionCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Acopio.Operacion.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Acopio.Operacion.FechaIngreso);
            });
        }
    }
}
