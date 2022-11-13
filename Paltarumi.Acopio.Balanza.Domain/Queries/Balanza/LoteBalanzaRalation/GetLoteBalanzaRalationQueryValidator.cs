using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanzaRalation
{
    public class GetLoteBalanzaRalationQueryValidator : QueryValidatorBase<GetLoteBalanzaRalationQuery>
    {
        private readonly IRepository<Entity.LoteBalanzaRalation> _lotebalanzaralationRepository;

        public GetLoteBalanzaRalationQueryValidator(IRepository<Entity.LoteBalanzaRalation> lotebalanzaralationRepository)
        {
            _lotebalanzaralationRepository = lotebalanzaralationRepository;

            RequiredField(x => x.Id, Resources.Balanza.LoteBalanzaRalation.IdLoteBalanzaRalation)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetLoteBalanzaRalationQuery command, int id, ValidationContext<GetLoteBalanzaRalationQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _lotebalanzaralationRepository.FindAll().Where(x => x.IdLoteBalanzaRalation == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
