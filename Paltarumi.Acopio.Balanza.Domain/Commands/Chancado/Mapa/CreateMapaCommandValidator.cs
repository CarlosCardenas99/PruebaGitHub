using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa
{
    public class CreateMapaCommandValidator : CommandValidatorBase<CreateMapaCommand>
    {
        public CreateMapaCommandValidator()
        {
            RequiredInformation(x => x.CreateDto);
        }
    }
}
