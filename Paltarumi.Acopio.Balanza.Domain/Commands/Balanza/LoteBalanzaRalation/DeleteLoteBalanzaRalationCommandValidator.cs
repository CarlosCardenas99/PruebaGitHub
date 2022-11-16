using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class DeleteLoteBalanzaRalationCommandValidator : CommandValidatorBase<DeleteLoteBalanzaRalationCommand>
    {
        private readonly IRepository<Entities.LoteBalanzaRalation> _repositoryBase;
        public DeleteLoteBalanzaRalationCommandValidator(IRepository<Entities.LoteBalanzaRalation> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.Id, Resources.Balanza.LoteBalanzaRalation.IdLoteBalanzaRalation)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteLoteBalanzaRalationCommand command, int id, ValidationContext<DeleteLoteBalanzaRalationCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLoteBalanzaRalation == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
