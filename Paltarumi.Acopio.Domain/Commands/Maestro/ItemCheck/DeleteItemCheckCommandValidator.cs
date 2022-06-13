using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ItemCheck
{
    public class DeleteItemCheckCommandValidator : CommandValidatorBase<DeleteItemCheckCommand>
    {
        private readonly IRepositoryBase<Entity.ItemCheck> _repositoryBase;
        public DeleteItemCheckCommandValidator(IRepositoryBase<Entity.ItemCheck> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Maestro.ItemCheck.IdItemCheck)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteItemCheckCommand command, int id, ValidationContext<DeleteItemCheckCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdItemCheck == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
