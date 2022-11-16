using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanza
{
    public class GetLoteBalanzaByCodigoQueryValidator : QueryValidatorBase<GetLoteBalanzaByCodigoQuery>
    {
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;

        public GetLoteBalanzaByCodigoQueryValidator(IRepository<Entities.LoteBalanza> loteBalanzaRepository)
        {
            _loteBalanzaRepository = loteBalanzaRepository;

            RequiredField(x => x.CodigoLote, Resources.Balanza.LoteBalanza.Codigo)
                .DependentRules(() =>
                {
                    RuleFor(x => x.CodigoLote!)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetLoteBalanzaByCodigoQuery command, string codigoLote, ValidationContext<GetLoteBalanzaByCodigoQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _loteBalanzaRepository.FindAll().Where(x => x.CodigoLote == codigoLote).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
