﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class GetTicketQueryValidator : QueryValidatorBase<GetTicketQuery>
    {
        private readonly IRepository<Entities.Ticket> _ticketRepository;

        public GetTicketQueryValidator(IRepository<Entities.Ticket> ticketRepository)
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

