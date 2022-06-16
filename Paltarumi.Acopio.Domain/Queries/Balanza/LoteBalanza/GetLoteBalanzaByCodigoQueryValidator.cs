using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteBalanza
{
    public class GetLoteBalanzaByCodigoQueryValidator : QueryValidatorBase<GetLoteBalanzaByCodigoQuery>
    {
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;

        public GetLoteBalanzaByCodigoQueryValidator(IRepository<Entity.LoteBalanza> loteBalanzaRepository)
        {
            _loteBalanzaRepository = loteBalanzaRepository;

            RequiredField(x => x.Codigo, Resources.Balanza.LoteBalanza.Codigo)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Codigo!)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetLoteBalanzaByCodigoQuery command, string codigo, ValidationContext<GetLoteBalanzaByCodigoQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _loteBalanzaRepository.FindAll().Where(x => x.Codigo == codigo).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
