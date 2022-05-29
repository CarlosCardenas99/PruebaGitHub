using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Maestro
{
    public class UpdateMaestroCommandValidator : CommandValidatorBase<UpdateMaestroCommand>
    {
        private readonly IRepositoryBase<Entity.Maestro> _repositoryBase;
        public UpdateMaestroCommandValidator(IRepositoryBase<Entity.Maestro> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdMaestro, Resources.Balanza.Maestro.IdMaestro)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdMaestro)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Balanza.Maestro.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Balanza.Maestro.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateMaestroCommand command, int id, ValidationContext<UpdateMaestroCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdMaestro == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
