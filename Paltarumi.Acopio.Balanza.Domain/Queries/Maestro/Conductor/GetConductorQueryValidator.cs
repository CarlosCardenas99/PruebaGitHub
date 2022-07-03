using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQueryValidator : QueryValidatorBase<GetConductorQuery>
    {
        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public GetConductorQueryValidator(IRepository<Entity.Conductor> conductorRepository)
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
