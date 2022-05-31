using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Maestro
{
    public class GetMaestroQueryValidator : QueryValidatorBase<GetMaestroQuery>
    {
        private readonly IRepositoryBase<Entity.Maestro> _maestroRepository;

        public GetMaestroQueryValidator(IRepositoryBase<Entity.Maestro> maestroRepository)
        {
            _maestroRepository = maestroRepository;

            RequiredField(x => x.Id, Resources.Balanza.Maestro.IdMaestro)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetMaestroQuery command, int id, ValidationContext<GetMaestroQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _maestroRepository.FindAll().Where(x => x.IdMaestro == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
