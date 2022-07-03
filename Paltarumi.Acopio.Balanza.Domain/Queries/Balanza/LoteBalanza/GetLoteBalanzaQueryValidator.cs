using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
{
    public class GetLoteBalanzaQueryValidator : QueryValidatorBase<GetLoteBalanzaQuery>
    {
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;

        public GetLoteBalanzaQueryValidator(IRepository<Entity.LoteBalanza> loteBalanzaRepository)
        {
            _loteBalanzaRepository = loteBalanzaRepository;

            RequiredField(x => x.Id, Resources.Balanza.LoteBalanza.IdLoteBalanza)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetLoteBalanzaQuery command, int id, ValidationContext<GetLoteBalanzaQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _loteBalanzaRepository.FindAll().Where(x => x.IdLoteBalanza == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
