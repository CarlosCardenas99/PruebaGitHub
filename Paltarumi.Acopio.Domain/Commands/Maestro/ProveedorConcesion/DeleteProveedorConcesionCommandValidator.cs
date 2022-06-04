using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ProveedorConcesion
{
    public class DeleteProveedorConcesionCommandValidator : CommandValidatorBase<DeleteProveedorConcesionCommand>
    {
        private readonly IRepositoryBase<Entity.ProveedorConcesion> _repositoryBase;
        public DeleteProveedorConcesionCommandValidator(IRepositoryBase<Entity.ProveedorConcesion> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Maestro.ProveedorConcesion.IdProveedorConcesion)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteProveedorConcesionCommand command, int id, ValidationContext<DeleteProveedorConcesionCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdProveedorConcesion == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
