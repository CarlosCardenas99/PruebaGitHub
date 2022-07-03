using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.ProveedorConcesion
{
    public class ListProveedorConcesionQueryValidator : QueryValidatorBase<ListProveedorConcesionQuery>
    {
        private readonly IRepository<Entity.ProveedorConcesion> _proveedorconcesionRepository;

        public ListProveedorConcesionQueryValidator(IRepository<Entity.ProveedorConcesion> proveedorconcesionRepository)
        {
            _proveedorconcesionRepository = proveedorconcesionRepository;

            RequiredField(x => x.IdProveedor, Resources.Maestro.ProveedorConcesion.IdProveedorConcesion)
                .DependentRules(() =>
                {
                    RuleFor(x => x.IdProveedor)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(ListProveedorConcesionQuery command, int id, ValidationContext<ListProveedorConcesionQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _proveedorconcesionRepository.FindAll().Where(x => x.IdProveedor == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
