using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class CreateLoteOperacionCommandValidator : CommandValidatorBase<CreateLoteOperacionCommand>
    {
        public CreateLoteOperacionCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Acopio.LoteOperacion.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Acopio.LoteOperacion.FechaIngreso);
            });
        }
    }
}
