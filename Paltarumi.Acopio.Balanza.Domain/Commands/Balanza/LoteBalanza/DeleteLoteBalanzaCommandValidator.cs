using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class DeleteLoteBalanzaCommandValidator : CommandValidatorBase<DeleteLoteBalanzaCommand>
    {
        private readonly IRepository<Entity.LoteBalanza> _repositoryBase;
        public DeleteLoteBalanzaCommandValidator(IRepository<Entity.LoteBalanza> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Balanza.LoteBalanza.IdLoteBalanza)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteLoteBalanzaCommand command, int id, ValidationContext<DeleteLoteBalanzaCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLoteBalanza == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
