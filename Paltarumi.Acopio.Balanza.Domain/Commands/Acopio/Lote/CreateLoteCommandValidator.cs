using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Lote
{
    public class CreateLoteCommandValidator : CommandValidatorBase<CreateLoteCommand>
    {
        public CreateLoteCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Acopio.Lote.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Acopio.Lote.FechaIngreso);
            });
        }
    }
}
