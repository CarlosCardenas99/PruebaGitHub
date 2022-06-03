using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Proveedor
{
    public class UpdateProveedorCommandValidator : CommandValidatorBase<UpdateProveedorCommand>
    {
        private readonly IRepositoryBase<Entity.Proveedor> _repositoryBase;
        public UpdateProveedorCommandValidator(IRepositoryBase<Entity.Proveedor> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdProveedor, Resources.Maestro.Proveedor.IdProveedor)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdProveedor)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Maestro.Proveedor.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Maestro.Proveedor.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateProveedorCommand command, int id, ValidationContext<UpdateProveedorCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdProveedor == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
