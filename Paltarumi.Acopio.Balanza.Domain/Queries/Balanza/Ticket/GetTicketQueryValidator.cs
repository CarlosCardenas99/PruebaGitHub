using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class GetTicketQueryValidator : QueryValidatorBase<GetTicketQuery>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;

        public GetTicketQueryValidator(IRepository<Entity.Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;

            RequiredField(x => x.Id, Resources.Balanza.Ticket.IdTicket)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetTicketQuery command, int id, ValidationContext<GetTicketQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _ticketRepository.FindAll().Where(x => x.IdTicket == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}

