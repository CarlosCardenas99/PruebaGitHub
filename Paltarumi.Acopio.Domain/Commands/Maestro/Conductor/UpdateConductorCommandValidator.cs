using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class UpdateConductorCommandValidator : CommandValidatorBase<UpdateConductorCommand>
    {
        private readonly IRepositoryBase<Entity.Conductor> _repositoryBase;
        public UpdateConductorCommandValidator(IRepositoryBase<Entity.Conductor> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdConductor, Resources.Maestro.Conductor.IdConductor)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdConductor)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Maestro.Conductor.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Maestro.Conductor.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateConductorCommand command, int id, ValidationContext<UpdateConductorCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdConductor == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
