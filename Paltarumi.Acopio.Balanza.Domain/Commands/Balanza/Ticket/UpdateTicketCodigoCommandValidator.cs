using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class UpdateTicketCodigoCommandValidator : CommandValidatorBase<UpdateTicketCodigoCommand>
    {
        private readonly IRepository<Entity.Ticket> _repositoryBase;
        public UpdateTicketCodigoCommandValidator(IRepository<Entity.Ticket> repositoryBase)
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
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Balanza.Ticket.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Balanza.Ticket.FechaIngreso);
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
