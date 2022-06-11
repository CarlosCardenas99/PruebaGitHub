using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyesReferenciales
{
    public class GetLeyesReferencialesQueryValidator : QueryValidatorBase<GetLeyesReferencialesQuery>
    {
        private readonly IRepositoryBase<Entity.LeyesReferenciales> _leyesreferencialesRepository;

        public GetLeyesReferencialesQueryValidator(IRepositoryBase<Entity.LeyesReferenciales> leyesreferencialesRepository)
        {
            _leyesreferencialesRepository = leyesreferencialesRepository;

            RequiredField(x => x.Id, Resources.Balanza.LeyesReferenciales.IdLeyesReferenciales)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetLeyesReferencialesQuery command, int id, ValidationContext<GetLeyesReferencialesQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _leyesreferencialesRepository.FindAll().Where(x => x.IdLeyesReferenciales == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
