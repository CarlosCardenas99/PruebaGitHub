using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo
{
    public class GetLoteCodigoQueryValidator : QueryValidatorBase<GetLoteCodigoQuery>
    {
        private readonly IRepository<Entity.LoteCodigo> _lotecodigoRepository;

        public GetLoteCodigoQueryValidator(IRepository<Entity.LoteCodigo> lotecodigoRepository)
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
