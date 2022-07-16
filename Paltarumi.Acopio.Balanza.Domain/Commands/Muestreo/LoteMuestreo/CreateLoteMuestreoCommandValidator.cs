using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class CreateLoteMuestreoCommandValidator : CommandValidatorBase<CreateLoteMuestreoCommand>
    {
        public CreateLoteMuestreoCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Muestreo.LoteMuestreo.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Muestreo.LoteMuestreo.FechaIngreso);
            });
        }
    }
}
