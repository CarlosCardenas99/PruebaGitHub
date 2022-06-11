using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyReferencial
{
    public class GetLeyReferencialQueryValidator : QueryValidatorBase<GetLeyReferencialQuery>
    {
        private readonly IRepositoryBase<Entity.LeyReferencial> _leyreferencialRepository;

        public GetLeyReferencialQueryValidator(IRepositoryBase<Entity.LeyReferencial> leyreferencialRepository)
        {
            _leyreferencialRepository = leyreferencialRepository;

            RequiredField(x => x.Id, Resources.Balanza.LeyReferencial.IdLeyReferencial)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetLeyReferencialQuery command, int id, ValidationContext<GetLeyReferencialQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _leyreferencialRepository.FindAll().Where(x => x.IdLeyReferencial == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
