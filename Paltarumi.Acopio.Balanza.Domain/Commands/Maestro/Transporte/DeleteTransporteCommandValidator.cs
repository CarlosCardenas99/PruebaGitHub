using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Transporte
{
    public class DeleteTransporteCommandValidator : CommandValidatorBase<DeleteTransporteCommand>
    {
        private readonly IRepository<Entity.Transporte> _repositoryBase;
        public DeleteTransporteCommandValidator(IRepository<Entity.Transporte> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Maestro.Transporte.IdTransporte)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteTransporteCommand command, int id, ValidationContext<DeleteTransporteCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdTransporte == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
