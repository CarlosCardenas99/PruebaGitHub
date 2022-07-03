using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Acopio.CheckList
{
    public class CreateCheckListCommandValidator : CommandValidatorBase<CreateCheckListCommand>
    {
        public CreateCheckListCommandValidator()
        {
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.CheckList.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.CheckList.FechaIngreso);
            });
        }
    }
}
