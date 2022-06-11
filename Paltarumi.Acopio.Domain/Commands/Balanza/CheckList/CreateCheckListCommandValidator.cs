using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.CheckList
{
    public class CreateCheckListCommandValidator : CommandValidatorBase<CreateCheckListCommand>
    {
        public CreateCheckListCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.CheckList.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.CheckList.FechaIngreso);
            });
        }
    }
}
