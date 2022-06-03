using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Concesion
{
    public class UpdateConcesionCommandValidator : CommandValidatorBase<UpdateConcesionCommand>
    {
        private readonly IRepositoryBase<Entity.Concesion> _repositoryBase;
        public UpdateConcesionCommandValidator(IRepositoryBase<Entity.Concesion> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdConcesion, Resources.Maestro.Concesion.IdConcesion)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdConcesion)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Maestro.Concesion.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Maestro.Concesion.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateConcesionCommand command, int id, ValidationContext<UpdateConcesionCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdConcesion == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
