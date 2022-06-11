using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.DuenoMuestra
{
    public class DeleteDuenoMuestraCommandValidator : CommandValidatorBase<DeleteDuenoMuestraCommand>
    {
        private readonly IRepositoryBase<Entity.DuenoMuestra> _repositoryBase;
        public DeleteDuenoMuestraCommandValidator(IRepositoryBase<Entity.DuenoMuestra> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Maestro.DuenoMuestra.IdDuenoMuestra)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteDuenoMuestraCommand command, int id, ValidationContext<DeleteDuenoMuestraCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdDuenoMuestra == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
