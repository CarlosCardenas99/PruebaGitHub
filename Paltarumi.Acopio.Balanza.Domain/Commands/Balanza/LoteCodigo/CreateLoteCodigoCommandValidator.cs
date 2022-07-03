using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class CreateLoteCodigoCommandValidator : CommandValidatorBase<CreateLoteCodigoCommand>
    {
        public CreateLoteCodigoCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.LoteCodigo.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.LoteCodigo.FechaIngreso);
            });
        }
    }
}
