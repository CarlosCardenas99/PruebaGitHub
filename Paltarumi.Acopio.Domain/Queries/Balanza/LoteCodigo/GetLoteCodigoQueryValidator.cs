using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo
{
    public class GetLoteCodigoQueryValidator : QueryValidatorBase<GetLoteCodigoQuery>
    {
        private readonly IRepositoryBase<Entity.LoteCodigo> _lotecodigoRepository;

        public GetLoteCodigoQueryValidator(IRepositoryBase<Entity.LoteCodigo> lotecodigoRepository)
        {
            _lotecodigoRepository = lotecodigoRepository;

            RequiredField(x => x.Id, Resources.Balanza.LoteCodigo.IdLoteCodigo)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetLoteCodigoQuery command, int id, ValidationContext<GetLoteCodigoQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _lotecodigoRepository.FindAll().Where(x => x.IdLoteCodigo == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
