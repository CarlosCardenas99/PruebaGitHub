using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class CreateLoteBalanzaCommandValidator : CommandValidatorBase<CreateLoteBalanzaCommand>
    {
        public CreateLoteBalanzaCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.LoteBalanza.Codigo, 4, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.LoteBalanza.FechaIngreso);
                //RequiredField(x => x.CreateDto.HoraIngreso, Resources.Balanza.LoteBalanza.HoraIngreso);
            });
        }
    }
}
