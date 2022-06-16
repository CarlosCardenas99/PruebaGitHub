using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Ubigeo
{
    public class GetUbigeoQueryValidator : QueryValidatorBase<GetUbigeoQuery>
    {
        private readonly IRepository<Entity.Ubigeo> _ubigeoRepository;

        public GetUbigeoQueryValidator(IRepository<Entity.Ubigeo> ubigeoRepository)
        {
            _ubigeoRepository = ubigeoRepository;

            RequiredField(x => x.CodigoUbigeo, Resources.Maestro.Ubigeo.CodigoUbigeo)
                .DependentRules(() =>
                {
                    RuleFor(x => x.CodigoUbigeo)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetUbigeoQuery command, string codigoUbigeo, ValidationContext<GetUbigeoQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _ubigeoRepository.FindAll().Where(x => x.CodigoUbigeo.Equals(codigoUbigeo)).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
