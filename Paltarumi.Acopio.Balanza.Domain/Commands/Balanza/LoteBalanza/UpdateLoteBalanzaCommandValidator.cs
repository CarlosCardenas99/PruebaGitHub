using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCommandValidator : CommandValidatorBase<UpdateLoteBalanzaCommand>
    {
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;

        public UpdateLoteBalanzaCommandValidator(IRepository<Entities.LoteBalanza> loteBalanzaRepository)
        {
            _loteBalanzaRepository = loteBalanzaRepository;

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
            var exists = await _loteBalanzaRepository.FindAll().Where(x => x.IdLoteBalanza == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);

            return true;
        }
    }
}
