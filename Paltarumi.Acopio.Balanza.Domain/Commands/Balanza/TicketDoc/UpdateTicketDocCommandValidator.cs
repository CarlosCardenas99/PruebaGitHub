using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.TicketDoc
{
    public class UpdateTicketDocCommandValidator : CommandValidatorBase<UpdateTicketDocCommand>
    {
        private readonly IRepository<Entity.TicketDoc> _repositoryBase;
        public UpdateTicketDocCommandValidator(IRepository<Entity.TicketDoc> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdTicketDoc, Resources.Balanza.TicketDoc.IdTicketDoc)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdTicketDoc)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Balanza.TicketDoc.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Balanza.TicketDoc.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateTicketDocCommand command, int id, ValidationContext<UpdateTicketDocCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdTicketDoc == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
