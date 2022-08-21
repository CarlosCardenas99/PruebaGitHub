using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class UpdateLoteChancadoCommandValidator : CommandValidatorBase<UpdateLoteChancadoCommand>
    {
        public UpdateLoteChancadoCommandValidator()
        {
            RequiredInformation(x => x.UpdateDto);
        }
    }
}
