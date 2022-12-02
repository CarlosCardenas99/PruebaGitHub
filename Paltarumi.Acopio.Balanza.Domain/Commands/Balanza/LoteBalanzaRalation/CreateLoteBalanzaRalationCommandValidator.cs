using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class CreateLoteBalanzaRalationCommandValidator : CommandValidatorBase<CreateLoteBalanzaRalationCommand>
    {
        private readonly IRepository<Entities.LoteBalanzaRalation> _loteBalanzaRepository;
        public CreateLoteBalanzaRalationCommandValidator(IRepository<Entities.LoteBalanzaRalation> loteBalanzaRepository)
        {
            _loteBalanzaRepository = loteBalanzaRepository;

            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                RequiredField(x => x.CreateDto.ItemLoteBalanzaRalation!.FirstOrDefault()!.IdLoteBalanzaOrigin.ToString(),Resources.Balanza.LoteBalanzaRalation.IdLoteBalanzaRalation)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.CreateDto.ItemLoteBalanzaRalation!.FirstOrDefault()!.IdLoteBalanzaOrigin)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.CreateDto.Codigo, Resources.Balanza.LoteBalanzaRalation.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Balanza.LoteBalanzaRalation.FechaIngreso);
            });
        }
        protected async Task<bool> ValidateExistenceAsync(CreateLoteBalanzaRalationCommand command, int id, ValidationContext<CreateLoteBalanzaRalationCommand> context, CancellationToken cancellationToken)
        {
            var idLotes = command.CreateDto.ItemLoteBalanzaRalation!.Select(x=>x.IdLoteBalanzaOrigin);

            var existe = await _loteBalanzaRepository.FindByAsNoTrackingAsync(x => idLotes.Contains(x.IdLoteBalanzaOrigin), x => x.IdLoteBalanzaOriginNavigation);

            if (existe.ToList().Count > 0)
            {
                var codigos = string.Join(",", existe.Select(x => x.IdLoteBalanzaOriginNavigation.CodigoLote));

                return CustomValidationMessage(context, String.Format(Resources.Common.CreateLoteRelacionExiste, codigos));
            }

            return true;
        }
    }
}
