using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Vehiculo
{
    public class CreateVehiculoCommandValidator : CommandValidatorBase<CreateVehiculoCommand>
    {
        private readonly IRepositoryBase<Entity.Maestro> _maestroRepositoryBase;

        public CreateVehiculoCommandValidator(IRepositoryBase<Entity.Maestro> maestroRepositoryBase)
        {
            _maestroRepositoryBase = maestroRepositoryBase;

            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    RequiredString(x => x.CreateDto.Placa, Resources.Maestro.Vehiculo.Placa, 5, 20);

                    RuleFor(x => x.CreateDto.IdTipoVehiculo)
                        .MustAsync(ValidateMaestroExistenceAsync)
                        .WithMessage(Resources.Maestro.Maestro.TipoVehiculoNotFound)
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.CreateDto).Must((command, dto, context) =>
                            {
                                if ((!dto.IdTipoVehiculo.HasValue || dto.IdTipoVehiculo == 0) && string.IsNullOrEmpty(dto.DescripcionTipoVehiculo))
                                    return CustomValidationMessage(context, string.Format(Resources.Common.FieldRequired, Resources.Maestro.Vehiculo.DescripcionTipoVehiculo));

                                return true;
                            })
                            .WithCustomValidationMessage();
                        });

                    RuleFor(x => x.CreateDto.IdVehiculoMarca)
                        .MustAsync(ValidateMaestroExistenceAsync)
                        .WithMessage(Resources.Maestro.Maestro.VehiculoMarcaNotFound)
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.CreateDto).Must((command, dto, context) =>
                            {
                                if ((!dto.IdVehiculoMarca.HasValue || dto.IdVehiculoMarca == 0) && string.IsNullOrEmpty(dto.DescripcionVehiculoMarca))
                                    return CustomValidationMessage(context, string.Format(Resources.Common.FieldRequired, Resources.Maestro.Vehiculo.DescripcionVehiculoMarca));

                                return true;
                            })
                            .WithCustomValidationMessage();
                        });
                });
        }

        protected async Task<bool> ValidateMaestroExistenceAsync(CreateVehiculoCommand command, int? idMaestro, ValidationContext<CreateVehiculoCommand> context, CancellationToken cancellationToken)
        {
            if (!idMaestro.HasValue || idMaestro == 0) return true;

            var exists = await _maestroRepositoryBase.FindAll().Where(x => x.IdMaestro == idMaestro).AnyAsync(cancellationToken);
            if (!exists) return false;

            return true;
        }
    }
}
