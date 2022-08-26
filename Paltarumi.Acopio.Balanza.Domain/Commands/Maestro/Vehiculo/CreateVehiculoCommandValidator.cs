using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Vehiculo
{
    public class CreateVehiculoCommandValidator : CommandValidatorBase<CreateVehiculoCommand>
    {
        private readonly IRepository<Entity.Maestro> _maestroRepositoryBase;
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepositoryBase;

        public CreateVehiculoCommandValidator(IRepository<Entity.Maestro> maestroRepositoryBase, IRepository<Entity.Vehiculo> vehiculoRepositoryBase)
        {
            _maestroRepositoryBase = maestroRepositoryBase;
            _vehiculoRepositoryBase = vehiculoRepositoryBase;

            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                RuleFor(x => x.CreateDto)
                    .MustAsync(ValidateExistenceAsync)
                    .WithCustomValidationMessage()
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
                                    if ((dto.IdTipoVehiculo == default || dto.IdTipoVehiculo == 0) && string.IsNullOrEmpty(dto.DescripcionTipoVehiculo))
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
                                    if ((dto.IdVehiculoMarca == default || dto.IdVehiculoMarca == 0) && string.IsNullOrEmpty(dto.DescripcionVehiculoMarca))
                                        return CustomValidationMessage(context, string.Format(Resources.Common.FieldRequired, Resources.Maestro.Vehiculo.DescripcionVehiculoMarca));

                                    return true;
                                })
                                .WithCustomValidationMessage();
                            });
                    });
            });
        }

        protected async Task<bool> ValidateMaestroExistenceAsync(CreateVehiculoCommand command, int idMaestro, ValidationContext<CreateVehiculoCommand> context, CancellationToken cancellationToken)
        {
            if (idMaestro == default) return true;

            var exists = await _maestroRepositoryBase.FindAll().Where(x => x.IdMaestro == idMaestro).AnyAsync(cancellationToken);
            if (!exists) return false;

            return true;
        }
        protected async Task<bool> ValidateExistenceAsync(CreateVehiculoCommand command, CreateVehiculoDto createDto, ValidationContext<CreateVehiculoCommand> context, CancellationToken cancellationToken)
        {
            createDto.Placa = createDto.Placa.ToUpper();
            if (createDto.Placa.Length == 6) createDto.Placa = createDto.Placa.Insert(3, "-");

            var exists = await _vehiculoRepositoryBase.FindAll().Where(x => x.Placa.ToUpper() == createDto.Placa && x.Activo == true).AnyAsync(cancellationToken);
            if (exists) return CustomValidationMessage(context, Resources.Common.DuplicatePlacaVehiculoRecord);

            return true;
        }
    }
}
