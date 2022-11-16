using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class UpdateTicketCodigoCommandValidator : CommandValidatorBase<UpdateTicketCodigoCommand>
    {
        private readonly IRepository<Entities.Ticket> _repositoryBase;
        public UpdateTicketCodigoCommandValidator(IRepository<Entities.Ticket> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto.IdTicket).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdTicket, Resources.Balanza.Ticket.IdTicket)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdTicket)
                            .MustAsync(ValidateExistenceAsync)
                            .MustAsync(ValidateExistenceNumberAsync)
                            .WithCustomValidationMessage();
                    });
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateTicketCodigoCommand command, int id, ValidationContext<UpdateTicketCodigoCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdTicket == id).AnyAsync(cancellationToken);

            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);

            return true;
        }

        protected async Task<bool> ValidateExistenceNumberAsync(UpdateTicketCodigoCommand command, int id, ValidationContext<UpdateTicketCodigoCommand> context, CancellationToken cancellationToken)
        {
            var existNumber = await _repositoryBase.FindAll().Where(x => x.IdTicket == id && x.Numero != null && x.Numero != string.Empty).AnyAsync(cancellationToken);

            if (existNumber) return CustomValidationMessage(context, Resources.Balanza.Ticket.UpdateTicketNumberFailed);

            return true;
        }
    }
}
