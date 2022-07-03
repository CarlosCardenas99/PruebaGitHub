using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Config.Modulo
{
    public class GetModuloQueryValidator : QueryValidatorBase<GetModuloQuery>
    {
        private readonly IRepository<Entity.Modulo> _moduloRepository;

        public GetModuloQueryValidator(IRepository<Entity.Modulo> moduloRepository)
        {
            _moduloRepository = moduloRepository;

            RequiredField(x => x.Id, Resources.Config.Modulo.IdModulo)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetModuloQuery command, int id, ValidationContext<GetModuloQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _moduloRepository.FindAll().Where(x => x.IdModulo == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
