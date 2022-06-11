using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.CheckList
{
    public class GetCheckListQueryValidator : QueryValidatorBase<GetCheckListQuery>
    {
        private readonly IRepositoryBase<Entity.CheckList> _checklistRepository;

        public GetCheckListQueryValidator(IRepositoryBase<Entity.CheckList> checklistRepository)
        {
            _checklistRepository = checklistRepository;

            RequiredField(x => x.Id, Resources.Balanza.CheckList.IdCheckList)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetCheckListQuery command, int id, ValidationContext<GetCheckListQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _checklistRepository.FindAll().Where(x => x.IdCheckList == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
