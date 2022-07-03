using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Maestro
{
    public class DeleteMaestroCommandValidator : CommandValidatorBase<DeleteMaestroCommand>
    {
        private readonly IRepository<Entity.Maestro> _repositoryBase;
        public DeleteMaestroCommandValidator(IRepository<Entity.Maestro> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Maestro.Maestro.IdMaestro)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteMaestroCommand command, int id, ValidationContext<DeleteMaestroCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdMaestro == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
