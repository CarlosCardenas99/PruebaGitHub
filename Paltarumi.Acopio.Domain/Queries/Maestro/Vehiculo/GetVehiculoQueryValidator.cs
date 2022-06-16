using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoQueryValidator : QueryValidatorBase<GetVehiculoQuery>
    {
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public GetVehiculoQueryValidator(IRepository<Entity.Vehiculo> vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;

            RequiredField(x => x.Id, Resources.Maestro.Vehiculo.IdVehiculo)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetVehiculoQuery command, int id, ValidationContext<GetVehiculoQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _vehiculoRepository.FindAll().Where(x => x.IdVehiculo == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
