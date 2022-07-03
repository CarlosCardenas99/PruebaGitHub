using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.ProveedorConcesion
{
    public class CreateProveedorConcesionCommandValidator : CommandValidatorBase<CreateProveedorConcesionCommand>
    {
        private readonly IRepository<Entity.ProveedorConcesion> _repositoryBase;
        public CreateProveedorConcesionCommandValidator(IRepository<Entity.ProveedorConcesion> repositoryBase)
        {
            _repositoryBase = repositoryBase;
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                RuleFor(x => x.CreateDto)
                    .MustAsync(ValidateExistenceAsync)
                    .WithCustomValidationMessage();
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.ProveedorConcesion.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.ProveedorConcesion.FechaIngreso);
            });
        }
        protected async Task<bool> ValidateExistenceAsync(CreateProveedorConcesionCommand command, CreateProveedorConcesionDto createDto, ValidationContext<CreateProveedorConcesionCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdProveedor == createDto.IdProveedor && x.IdConcesion == createDto.IdConcesion).AnyAsync(cancellationToken);
            if (exists) return CustomValidationMessage(context, Resources.Common.DuplicateRecord);
            return true;
        }
    }
}
