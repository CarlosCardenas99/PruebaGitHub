using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class UpdateLoteOperacionStatusCommandValidator : CommandValidatorBase<UpdateLoteOperacionStatusCommand>
    {
        private readonly IRepository<Entity.LoteOperacion> _operacionRepository;
        public UpdateLoteOperacionStatusCommandValidator(IRepository<Entity.LoteOperacion> operacionRepository)
        {
            _operacionRepository = operacionRepository;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.Modulo, Resources.Acopio.LoteOperacion.Modulo)
                    .DependentRules(() =>
                    {
                        RequiredField(x => x.UpdateDto.Operacion, Resources.Acopio.LoteOperacion.Operacion)
                        .DependentRules(() =>
                        {
                            RequiredField(x => x.UpdateDto.CodigoLote, Resources.Acopio.LoteOperacion.CodigoLote)
                            .DependentRules(() =>
                            {
                                RuleFor(x => x.UpdateDto)
                                    .MustAsync(ValidateExistenceAsync)
                                    .WithCustomValidationMessage();
                            });
                        });
                    });
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateLoteOperacionStatusCommand command, UpdateLoteOperacionStatusDto updateDto, ValidationContext<UpdateLoteOperacionStatusCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _operacionRepository
                .FindAll()
                .Where(x =>
                    x.IdOperacionNavigation.IdModuloNavigation.Nombre == updateDto.Modulo &&
                    x.IdOperacionNavigation.Codigo == updateDto.Operacion &&
                    x.IdLoteNavigation.CodigoLote == updateDto.CodigoLote)
                .AnyAsync(cancellationToken);

            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);

            return true;
        }
    }
}
