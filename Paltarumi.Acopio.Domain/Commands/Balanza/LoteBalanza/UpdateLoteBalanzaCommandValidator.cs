using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCommandValidator : CommandValidatorBase<UpdateLoteBalanzaCommand>
    {
        private readonly IRepositoryBase<Entity.LoteBalanza> _repositoryBase;
        public UpdateLoteBalanzaCommandValidator(IRepositoryBase<Entity.LoteBalanza> repositoryBase)
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
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Balanza.LoteBalanza.Codigo, 4, 10);
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
