using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Acopio.CheckList
{
    public class UpdateCheckListCommandValidator : CommandValidatorBase<UpdateCheckListCommand>
    {
        private readonly IRepository<Entity.CheckList> _repositoryBase;
        public UpdateCheckListCommandValidator(IRepository<Entity.CheckList> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdCheckList, Resources.Maestro.CheckList.IdCheckList)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdCheckList)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Maestro.CheckList.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Maestro.CheckList.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateCheckListCommand command, int id, ValidationContext<UpdateCheckListCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdCheckList == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
