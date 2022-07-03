using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo
{
    public class UpdateVehiculoCommandValidator : CommandValidatorBase<UpdateVehiculoCommand>
    {
        private readonly IRepository<Entity.Maestro> _maestroRepositoryBase;
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepositoryBase;

        public UpdateVehiculoCommandValidator(
            IRepository<Entity.Maestro> maestroRepositoryBase,
            IRepository<Entity.Vehiculo> vehiculoRepositoryBase
        )
        {
            _maestroRepositoryBase = maestroRepositoryBase;
            _vehiculoRepositoryBase = vehiculoRepositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdVehiculo, Resources.Maestro.Vehiculo.IdVehiculo)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdVehiculo)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage()
                            .DependentRules(() =>
                            {
                                RequiredString(x => x.UpdateDto.Placa, Resources.Maestro.Vehiculo.Placa, 5, 20);

                                RuleFor(x => x.UpdateDto.IdTipoVehiculo)
                                    .MustAsync(ValidateMaestroExistenceAsync)
                                    .WithMessage(Resources.Maestro.Maestro.TipoVehiculoNotFound)
                                    .DependentRules(() =>
                                    {
                                        RuleFor(x => x.UpdateDto).Must((command, dto, context) =>
                                        {
                                            if ((dto.IdTipoVehiculo == default || dto.IdTipoVehiculo == 0) && string.IsNullOrEmpty(dto.DescripcionTipoVehiculo))
                                                return CustomValidationMessage(context, string.Format(Resources.Common.FieldRequired, Resources.Maestro.Vehiculo.DescripcionTipoVehiculo));

                                            return true;
                                        })
                                        .WithCustomValidationMessage();
                                    });

                                RuleFor(x => x.UpdateDto.IdVehiculoMarca)
                                    .MustAsync(ValidateMaestroExistenceAsync)
                                    .WithMessage(Resources.Maestro.Maestro.VehiculoMarcaNotFound)
                                    .DependentRules(() =>
                                    {
                                        RuleFor(x => x.UpdateDto).Must((command, dto, context) =>
                                        {
                                            if ((dto.IdVehiculoMarca == default || dto.IdVehiculoMarca == 0) && string.IsNullOrEmpty(dto.DescripcionVehiculoMarca))
                                                return CustomValidationMessage(context, string.Format(Resources.Common.FieldRequired, Resources.Maestro.Vehiculo.DescripcionVehiculoMarca));

                                            return true;
                                        })
                                        .WithCustomValidationMessage();
                                    });
                            });
                    });
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateVehiculoCommand command, int id, ValidationContext<UpdateVehiculoCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _vehiculoRepositoryBase.FindAll().Where(x => x.IdVehiculo == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }

        protected async Task<bool> ValidateMaestroExistenceAsync(UpdateVehiculoCommand command, int idMaestro, ValidationContext<UpdateVehiculoCommand> context, CancellationToken cancellationToken)
        {
            if (idMaestro == default || idMaestro == 0) return true;

            var exists = await _maestroRepositoryBase.FindAll().Where(x => x.IdMaestro == idMaestro).AnyAsync(cancellationToken);
            if (!exists) return false;

            return true;
        }
    }
}
