﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Ticket
{
    public class UpdateTicketCommandValidator : CommandValidatorBase<UpdateTicketCommand>
    {
        private readonly IRepositoryBase<Entity.Ticket> _repositoryBase;
        public UpdateTicketCommandValidator(IRepositoryBase<Entity.Ticket> repositoryBase)
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
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Balanza.Ticket.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Balanza.Ticket.FechaIngreso);
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
