using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo
{
    public class UpdateVehiculoCommandValidator : CommandValidatorBase<UpdateVehiculoCommand>
    {
        private readonly IRepositoryBase<Entity.Vehiculo> _repositoryBase;
        public UpdateVehiculoCommandValidator(IRepositoryBase<Entity.Vehiculo> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdVehiculo, Resources.Maestro.Vehiculo.IdVehiculo)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdVehiculo)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Maestro.Vehiculo.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Maestro.Vehiculo.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateVehiculoCommand command, int id, ValidationContext<UpdateVehiculoCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdVehiculo == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
