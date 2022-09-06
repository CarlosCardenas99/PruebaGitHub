using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCommandValidator : CommandValidatorBase<UpdateLoteBalanzaCommand>
    {
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;

        public UpdateLoteBalanzaCommandValidator(IRepository<Entity.LoteBalanza> loteBalanzaRepository)
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
            if (command.UpdateDto.EsPartido)
            {
                var loteBalanza = _loteBalanzaRepository.GetByAsNoTrackingAsync(x => x.IdLoteBalanza == id);

                var sumaPeso =
                    command.UpdateDto.TicketDetails?.Where(y => y.Activo == true).Sum(x => x.PesoNeto100)
                    +
                    command.UpdateDto.TicketDetails?.Where(y => y.Activo == true).Sum(x => x.PesoNetoCarreta100);

                if (sumaPeso != loteBalanza.Result?.Tmh100)
                    return CustomValidationMessage(context, Resources.Balanza.LoteBalanza.PesoTicketNoConcideConOriginal);

            }

            var exists = await _loteBalanzaRepository.FindAll().Where(x => x.IdLoteBalanza == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);

            return true;
        }
    }
}
