using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCommandValidator : CommandValidatorBase<UpdateLoteBalanzaCommand>
    {
        private readonly IRepository<Entity.LoteBalanza> _repositoryBase;
        public UpdateLoteBalanzaCommandValidator(IRepository<Entity.LoteBalanza> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdLoteBalanza, Resources.Balanza.LoteBalanza.IdLoteBalanza)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdLoteBalanza)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateLoteBalanzaCommand command, int id, ValidationContext<UpdateLoteBalanzaCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLoteBalanza == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
