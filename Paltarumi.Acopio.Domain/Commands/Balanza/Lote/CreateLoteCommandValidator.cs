using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class CreateLoteCommandValidator : CommandValidatorBase<CreateLoteCommand>
    {
        public CreateLoteCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.Lote.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.Lote.FechaIngreso);
                //RequiredField(x => x.CreateDto.HoraIngreso, Resources.Balanza.Lote.HoraIngreso);
            });
        }
    }
}
