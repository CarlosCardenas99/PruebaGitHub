using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.DuenoMuestra
{
    public class CreateDuenoMuestraCommandValidator : CommandValidatorBase<CreateDuenoMuestraCommand>
    {
        public CreateDuenoMuestraCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.DuenoMuestra.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.DuenoMuestra.FechaIngreso);
            });
        }
    }
}
