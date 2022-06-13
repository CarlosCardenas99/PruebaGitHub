using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.ItemCheck
{
    public class GetItemCheckQueryValidator : QueryValidatorBase<GetItemCheckQuery>
    {
        private readonly IRepositoryBase<Entity.ItemCheck> _itemcheckRepository;

        public GetItemCheckQueryValidator(IRepositoryBase<Entity.ItemCheck> itemcheckRepository)
        {
            _itemcheckRepository = itemcheckRepository;

            RequiredField(x => x.Id, Resources.Maestro.ItemCheck.IdItemCheck)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetItemCheckQuery command, int id, ValidationContext<GetItemCheckQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _itemcheckRepository.FindAll().Where(x => x.IdItemCheck == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
