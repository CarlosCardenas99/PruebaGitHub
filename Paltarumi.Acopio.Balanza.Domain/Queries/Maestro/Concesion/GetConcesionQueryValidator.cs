using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Concesion
{
    public class GetConcesionQueryValidator : QueryValidatorBase<GetConcesionQuery>
    {
        private readonly IRepository<Entity.Concesion> _concesionRepository;

        public GetConcesionQueryValidator(IRepository<Entity.Concesion> concesionRepository)
        {
            _concesionRepository = concesionRepository;

            RequiredField(x => x.Id, Resources.Maestro.Concesion.IdConcesion)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetConcesionQuery command, int id, ValidationContext<GetConcesionQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _concesionRepository.FindAll().Where(x => x.IdConcesion == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
