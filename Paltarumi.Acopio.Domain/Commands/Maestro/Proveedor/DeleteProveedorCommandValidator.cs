using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Proveedor
{
    public class DeleteProveedorCommandValidator : CommandValidatorBase<DeleteProveedorCommand>
    {
        private readonly IRepositoryBase<Entity.Proveedor> _repositoryBase;
        public DeleteProveedorCommandValidator(IRepositoryBase<Entity.Proveedor> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Maestro.Proveedor.IdProveedor)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteProveedorCommand command, int id, ValidationContext<DeleteProveedorCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdProveedor == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
