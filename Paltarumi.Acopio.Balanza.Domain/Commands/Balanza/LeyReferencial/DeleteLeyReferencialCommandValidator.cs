using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LeyReferencial
{
    public class DeleteLeyReferencialCommandValidator : CommandValidatorBase<DeleteLeyReferencialCommand>
    {
        private readonly IRepository<Entity.LeyReferencial> _repositoryBase;
        public DeleteLeyReferencialCommandValidator(IRepository<Entity.LeyReferencial> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Balanza.LeyReferencial.IdLeyReferencial)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteLeyReferencialCommand command, int id, ValidationContext<DeleteLeyReferencialCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLeyReferencial == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
