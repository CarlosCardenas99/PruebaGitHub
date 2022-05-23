using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class DeleteConductorCommandValidator : CommandValidatorBase<DeleteConductorCommand>
    {
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public DeleteConductorCommandValidator(IRepositoryBase<Entity.Conductor> conductorRepository)
        {
            _conductorRepository = conductorRepository;

            RequiredField(x => x.Id, Resources.Maestro.Conductor.IdConductor)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(DeleteConductorCommand command, int id, ValidationContext<DeleteConductorCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _conductorRepository.FindAll().Where(x => x.IdConductor == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.DeleteRecordNotFound);
            return true;
        }
    }
}
