using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ProveedorConcesion
{
    public class GetProveedorConcesionQueryValidator : QueryValidatorBase<GetProveedorConcesionQuery>
    {
        private readonly IRepositoryBase<Entity.ProveedorConcesion> _proveedorconcesionRepository;

        public GetProveedorConcesionQueryValidator(IRepositoryBase<Entity.ProveedorConcesion> proveedorconcesionRepository)
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

        protected async Task<bool> ValidateExistenceAsync(GetProveedorConcesionQuery command, int id, ValidationContext<GetProveedorConcesionQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _proveedorconcesionRepository.FindAll().Where(x => x.IdProveedorConcesion == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
