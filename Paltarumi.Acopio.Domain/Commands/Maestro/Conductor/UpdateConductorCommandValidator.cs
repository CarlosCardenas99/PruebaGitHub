using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class UpdateConductorCommandValidator : CommandValidatorBase<UpdateConductorCommand>
    {
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public UpdateConductorCommandValidator(IRepositoryBase<Entity.Conductor> conductorRepository)
        {
            _conductorRepository = conductorRepository;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdConductor, Resources.Maestro.Conductor.IdConductor)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdConductor)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                RequiredString(x => x.UpdateDto.RazonSocial, Resources.Maestro.Conductor.RazonSocial, 3, 100);
                RequiredString(x => x.UpdateDto.CodigoTipoDocumento, Resources.Maestro.Conductor.CodigoTipoDocumento, 2, 2);
                RequiredString(x => x.UpdateDto.Numero, Resources.Maestro.Conductor.Numero, 8, 20);
                RequiredString(x => x.UpdateDto.Licencia, Resources.Maestro.Conductor.Licencia, 8, 20);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateConductorCommand command, int id, ValidationContext<UpdateConductorCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _conductorRepository.FindAll().Where(x => x.IdConductor == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
