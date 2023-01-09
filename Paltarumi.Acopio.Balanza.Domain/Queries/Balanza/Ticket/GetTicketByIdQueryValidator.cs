using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;



namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class GetTicketByIdQueryValidator : QueryValidatorBase<GetTicketByIdQuery>
    {
        private readonly IRepository<Entities.Ticket> _ticketRepository;

        public GetTicketByIdQueryValidator(IRepository<Entities.Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;

            RequiredField(x => x.IdTicket, Resources.Balanza.Ticket.IdTicket)
                .DependentRules(() =>
                {
                    RuleFor(x => x.IdTicket)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetTicketByIdQuery command, int id, ValidationContext<GetTicketByIdQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _ticketRepository.FindAll().Where(x => x.IdTicket == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.IdNoEncontrado);
            return true;
        }




    }
}
