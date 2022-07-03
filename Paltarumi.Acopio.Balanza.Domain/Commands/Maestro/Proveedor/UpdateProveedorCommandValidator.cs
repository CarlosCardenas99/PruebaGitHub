using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Proveedor
{
    public class UpdateProveedorCommandValidator : CommandValidatorBase<UpdateProveedorCommand>
    {
        private readonly IRepository<Entity.Proveedor> _repositoryBase;
        public UpdateProveedorCommandValidator(IRepository<Entity.Proveedor> repositoryBase)
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

            var existsRuc = await _repositoryBase.FindAll().Where(x => x.IdProveedor != command.UpdateDto.IdProveedor && x.Ruc == command.UpdateDto.Ruc && x.Activo == true).AnyAsync(cancellationToken);
            if (existsRuc) return CustomValidationMessage(context, Resources.Common.DuplicateRucRecord);

            return true;
        }
    }
}
