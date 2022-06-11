using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Recodificacion
{
    public class DeleteRecodificacionCommandValidator : CommandValidatorBase<DeleteRecodificacionCommand>
    {
        private readonly IRepositoryBase<Entity.Recodificacion> _repositoryBase;
        public DeleteRecodificacionCommandValidator(IRepositoryBase<Entity.Recodificacion> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Balanza.Recodificacion.IdRecodificacion)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteRecodificacionCommand command, int id, ValidationContext<DeleteRecodificacionCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdRecodificacion == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
