using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ProveedorConcesion
{
    public class UpdateProveedorConcesionCommandValidator : CommandValidatorBase<UpdateProveedorConcesionCommand>
    {
        private readonly IRepository<Entity.ProveedorConcesion> _repositoryBase;
        public UpdateProveedorConcesionCommandValidator(IRepository<Entity.ProveedorConcesion> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdProveedorConcesion, Resources.Maestro.ProveedorConcesion.IdProveedorConcesion)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdProveedorConcesion)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Maestro.ProveedorConcesion.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Maestro.ProveedorConcesion.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateProveedorConcesionCommand command, int id, ValidationContext<UpdateProveedorConcesionCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdProveedorConcesion == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
