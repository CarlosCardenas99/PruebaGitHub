using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteCheckList
{
    public class CreateLoteCheckListCommandValidator : CommandValidatorBase<CreateLoteCheckListCommand>
    {
        public CreateLoteCheckListCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Acopio.LoteCheckList.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Acopio.LoteCheckList.FechaIngreso);
            });
        }
    }
}
