using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Transporte
{
    public class GetTransporteQueryValidator : QueryValidatorBase<GetTransporteQuery>
    {
        private readonly IRepository<Entity.Transporte> _transporteRepository;

        public GetTransporteQueryValidator(IRepository<Entity.Transporte> transporteRepository)
        {
            _transporteRepository = transporteRepository;

            RequiredField(x => x.Id, Resources.Maestro.Transporte.IdTransporte)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetTransporteQuery command, int id, ValidationContext<GetTransporteQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _transporteRepository.FindAll().Where(x => x.IdTransporte == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
