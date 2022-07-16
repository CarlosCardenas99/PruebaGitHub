using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class CreateLoteChancadoCommandValidator : CommandValidatorBase<CreateLoteChancadoCommand>
    {
        public CreateLoteChancadoCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Chancado.LoteChancado.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Chancado.LoteChancado.FechaIngreso);
            });
        }
    }
}
