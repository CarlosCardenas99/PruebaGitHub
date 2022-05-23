using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQueryValidator : QueryValidatorBase<GetConductorQuery>
    {
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public GetConductorQueryValidator(IRepositoryBase<Entity.Conductor> conductorRepository)
        {
            _conductorRepository = conductorRepository;

            RequiredField(x => x.Id, Resources.Maestro.Conductor.IdConductor)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetConductorQuery command, int id, ValidationContext<GetConductorQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _conductorRepository.FindAll().Where(x => x.IdConductor == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
