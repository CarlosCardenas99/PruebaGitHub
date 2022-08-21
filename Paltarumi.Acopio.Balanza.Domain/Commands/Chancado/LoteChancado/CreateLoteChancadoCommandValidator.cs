using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class CreateLoteChancadoCommandValidator : CommandValidatorBase<CreateLoteChancadoCommand>
    {
        public CreateLoteChancadoCommandValidator()
        {
            RequiredInformation(x => x.CreateDto);
        }
    }
}
