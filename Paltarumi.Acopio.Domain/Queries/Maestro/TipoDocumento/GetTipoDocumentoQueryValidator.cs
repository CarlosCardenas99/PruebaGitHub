using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.TipoDocumento
{
    public class GetTipoDocumentoQueryValidator : QueryValidatorBase<GetTipoDocumentoQuery>
    {
        private readonly IRepository<Entity.TipoDocumento> _tipodocumentoRepository;

        public GetTipoDocumentoQueryValidator(IRepository<Entity.TipoDocumento> tipodocumentoRepository)
        {
            _tipodocumentoRepository = tipodocumentoRepository;

            RequiredField(x => x.Id, Resources.Maestro.TipoDocumento.CodigoTipoDocumento)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetTipoDocumentoQuery command, string id, ValidationContext<GetTipoDocumentoQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _tipodocumentoRepository.FindAll().Where(x => x.CodigoTipoDocumento.Equals(id)).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
