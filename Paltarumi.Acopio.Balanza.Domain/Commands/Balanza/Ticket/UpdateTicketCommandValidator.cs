using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class UpdateTicketCommandValidator : CommandValidatorBase<UpdateTicketCommand>
    {
        private readonly IRepository<Entities.Ticket> _repositoryBase;
        public UpdateTicketCommandValidator(IRepository<Entities.Ticket> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdTicket, Resources.Balanza.Ticket.IdTicket)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdTicket)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateTicketCommand command, int id, ValidationContext<UpdateTicketCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdTicket == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
