using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Recodificacion
{
    public class CreateRecodificacionCommandValidator : CommandValidatorBase<CreateRecodificacionCommand>
    {
        public CreateRecodificacionCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.Recodificacion.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.Recodificacion.FechaIngreso);
            });
        }
    }
}
