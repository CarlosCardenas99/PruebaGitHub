using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class UpdateLoteBalanzaRalationCommandValidator : CommandValidatorBase<UpdateLoteBalanzaRalationCommand>
    {
        private readonly IRepository<Entities.LoteBalanzaRalation> _repositoryBase;
        public UpdateLoteBalanzaRalationCommandValidator(IRepository<Entities.LoteBalanzaRalation> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdLoteBalanzaRalation, Resources.Balanza.LoteBalanzaRalation.IdLoteBalanzaRalation)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdLoteBalanzaRalation)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateLoteBalanzaRalationCommand command, int id, ValidationContext<UpdateLoteBalanzaRalationCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLoteBalanzaRalation == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
