using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Maestro
{
    public class GetMaestroQueryValidator : QueryValidatorBase<GetMaestroQuery>
    {
        private readonly IRepository<Entity.Maestro> _maestroRepository;

        public GetMaestroQueryValidator(IRepository<Entity.Maestro> maestroRepository)
        {
            _maestroRepository = maestroRepository;

            RequiredField(x => x.Id, Resources.Maestro.Maestro.IdMaestro)
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
