using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoByPlacaQueryValidator : QueryValidatorBase<GetVehiculoByPlacaQuery>
    {
        private readonly IRepository<Entity.Vehiculo> _vehiculoRepository;

        public GetVehiculoByPlacaQueryValidator(IRepository<Entity.Vehiculo> vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;

            RequiredField(x => x.Placa, Resources.Maestro.Vehiculo.Placa)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Placa)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetVehiculoByPlacaQuery command, string placa, ValidationContext<GetVehiculoByPlacaQuery> context, CancellationToken cancellationToken)
        {
            placa = placa.Replace(" ", string.Empty);
            placa = placa.ToUpper();
            if (placa.Length == 6) placa = placa.Insert(3, "-");
            
            var exists = await _vehiculoRepository.FindAll().Where(x => x.Placa.Equals(placa)).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
