using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class GetTicketByCodigoQueryValidator : QueryValidatorBase<GetTicketByCodigoQuery>
    {
        private readonly IRepository<Entities.Ticket> _ticketRepository;

        public GetTicketByCodigoQueryValidator(IRepository<Entities.Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;

            RequiredField(x => x.IdVehiculo, Resources.Balanza.Ticket.IdTicket)
                .DependentRules(() =>
                {
                    RuleFor(x => x.IdVehiculo)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetTicketByCodigoQuery command, int IdVehiculo, ValidationContext<GetTicketByCodigoQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _ticketRepository.FindAll().Where(x => x.IdVehiculo == IdVehiculo).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.IdNoEncontrado);
            return true;
        }




    }
}
