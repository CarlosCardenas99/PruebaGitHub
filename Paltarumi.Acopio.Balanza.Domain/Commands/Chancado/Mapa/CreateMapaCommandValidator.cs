using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa
{
    public class CreateMapaCommandValidator : CommandValidatorBase<CreateMapaCommand>
    {
        public CreateMapaCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Chancado.Mapa.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Chancado.Mapa.FechaIngreso);
            });
        }
    }
}
