using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyesReferenciales
{
    public class DeleteLeyesReferencialesCommandValidator : CommandValidatorBase<DeleteLeyesReferencialesCommand>
    {
        private readonly IRepositoryBase<Entity.LeyesReferenciales> _repositoryBase;
        public DeleteLeyesReferencialesCommandValidator(IRepositoryBase<Entity.LeyesReferenciales> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Balanza.LeyesReferenciales.IdLeyesReferenciales)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteLeyesReferencialesCommand command, int id, ValidationContext<DeleteLeyesReferencialesCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLeyesReferenciales == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
