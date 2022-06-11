using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Recodificacion
{
    public class GetRecodificacionQueryValidator : QueryValidatorBase<GetRecodificacionQuery>
    {
        private readonly IRepositoryBase<Entity.Recodificacion> _recodificacionRepository;

        public GetRecodificacionQueryValidator(IRepositoryBase<Entity.Recodificacion> recodificacionRepository)
        {
            _recodificacionRepository = recodificacionRepository;

            RequiredField(x => x.Id, Resources.Balanza.Recodificacion.IdRecodificacion)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetRecodificacionQuery command, int id, ValidationContext<GetRecodificacionQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _recodificacionRepository.FindAll().Where(x => x.IdRecodificacion == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
