using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQueryValidator : QueryValidatorBase<GetProveedorQuery>
    {
        private readonly IRepository<Entity.Proveedor> _proveedorRepository;

        public GetProveedorQueryValidator(IRepository<Entity.Proveedor> proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;

            RequiredField(x => x.Id, Resources.Maestro.Proveedor.IdProveedor)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetProveedorQuery command, int id, ValidationContext<GetProveedorQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _proveedorRepository.FindAll().Where(x => x.IdProveedor == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
