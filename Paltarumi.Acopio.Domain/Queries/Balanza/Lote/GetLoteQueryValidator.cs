using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Lote
{
    public class GetLoteQueryValidator : QueryValidatorBase<GetLoteQuery>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;

        public GetLoteQueryValidator(IRepositoryBase<Entity.Lote> loteRepository)
        {
            _loteRepository = loteRepository;

            RequiredField(x => x.Id, Resources.Balanza.Lote.IdLote)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetLoteQuery command, int id, ValidationContext<GetLoteQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _loteRepository.FindAll().Where(x => x.IdLote == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
