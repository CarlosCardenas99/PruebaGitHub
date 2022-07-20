using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.TicketDoc
{
    public class GetTicketDocQueryValidator : QueryValidatorBase<GetTicketDocQuery>
    {
        private readonly IRepository<Entity.TicketDoc> _ticketdocRepository;

        public GetTicketDocQueryValidator(IRepository<Entity.TicketDoc> ticketdocRepository)
        {
            _ticketdocRepository = ticketdocRepository;

            RequiredField(x => x.Id, Resources.Balanza.TicketDoc.IdTicketDoc)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetTicketDocQuery command, int id, ValidationContext<GetTicketDocQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _ticketdocRepository.FindAll().Where(x => x.IdTicketDoc == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
