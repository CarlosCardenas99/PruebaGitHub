using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCheckList
{
    public class CreateLoteCheckListCommandValidator : CommandValidatorBase<CreateLoteCheckListCommand>
    {
        public CreateLoteCheckListCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.LoteCheckList.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.LoteCheckList.FechaIngreso);
            });
        }
    }
}
