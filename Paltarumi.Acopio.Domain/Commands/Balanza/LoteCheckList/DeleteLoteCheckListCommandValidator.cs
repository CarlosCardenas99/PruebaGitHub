using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCheckList
{
    public class DeleteLoteCheckListCommandValidator : CommandValidatorBase<DeleteLoteCheckListCommand>
    {
        private readonly IRepositoryBase<Entity.LoteCheckList> _repositoryBase;
        public DeleteLoteCheckListCommandValidator(IRepositoryBase<Entity.LoteCheckList> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Balanza.LoteCheckList.IdLoteCheckList)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteLoteCheckListCommand command, int id, ValidationContext<DeleteLoteCheckListCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLoteCheckList == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
