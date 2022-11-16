using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa
{
    public class UpdateMapaCommandValidator : CommandValidatorBase<UpdateMapaCommand>
    {
        public UpdateMapaCommandValidator()
        {
            RequiredInformation(x => x.UpdateDto);
        }
    }
}
