using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraQueryValidator : QueryValidatorBase<GetDuenoMuestraQuery>
    {
        private readonly IRepositoryBase<Entity.DuenoMuestra> _duenomuestraRepository;

        public GetDuenoMuestraQueryValidator(IRepositoryBase<Entity.DuenoMuestra> duenomuestraRepository)
        {
            _duenomuestraRepository = duenomuestraRepository;

            RequiredField(x => x.Id, Resources.Maestro.DuenoMuestra.IdDuenoMuestra)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetDuenoMuestraQuery command, int id, ValidationContext<GetDuenoMuestraQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _duenomuestraRepository.FindAll().Where(x => x.IdDuenoMuestra == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
