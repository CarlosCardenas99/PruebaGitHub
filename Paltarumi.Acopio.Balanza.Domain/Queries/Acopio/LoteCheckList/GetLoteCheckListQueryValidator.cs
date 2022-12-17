using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteCheckList
{
    public class GetLoteCheckListQueryValidator : QueryValidatorBase<GetLoteCheckListQuery>
    {
        private readonly IRepository<Entity.LoteCheckList> _lotechecklistRepository;

        public GetLoteCheckListQueryValidator(IRepository<Entity.LoteCheckList> lotechecklistRepository)
        {
            _lotechecklistRepository = lotechecklistRepository;

            RequiredField(x => x.Id, Resources.Acopio.LoteCheckList.IdLoteCheckList)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetLoteCheckListQuery command, int id, ValidationContext<GetLoteCheckListQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _lotechecklistRepository.FindAll().Where(x => x.IdLoteCheckList == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
