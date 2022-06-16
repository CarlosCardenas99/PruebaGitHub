using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.DuenoMuestra
{
    public class UpdateDuenoMuestraCommandValidator : CommandValidatorBase<UpdateDuenoMuestraCommand>
    {
        private readonly IRepository<Entity.DuenoMuestra> _repositoryBase;
        public UpdateDuenoMuestraCommandValidator(IRepository<Entity.DuenoMuestra> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdDuenoMuestra, Resources.Maestro.DuenoMuestra.IdDuenoMuestra)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdDuenoMuestra)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Maestro.DuenoMuestra.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Maestro.DuenoMuestra.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateDuenoMuestraCommand command, int id, ValidationContext<UpdateDuenoMuestraCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdDuenoMuestra == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
