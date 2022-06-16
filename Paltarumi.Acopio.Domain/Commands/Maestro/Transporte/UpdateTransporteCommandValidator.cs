using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Transporte
{
    public class UpdateTransporteCommandValidator : CommandValidatorBase<UpdateTransporteCommand>
    {
        private readonly IRepository<Entity.Transporte> _repositoryBase;
        public UpdateTransporteCommandValidator(IRepository<Entity.Transporte> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdTransporte, Resources.Maestro.Transporte.IdTransporte)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdTransporte)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Maestro.Transporte.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Maestro.Transporte.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateTransporteCommand command, int id, ValidationContext<UpdateTransporteCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdTransporte == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);

            var existsRuc = await _repositoryBase.FindAll().Where(x => x.IdTransporte != command.UpdateDto.IdTransporte && x.Ruc == command.UpdateDto.Ruc && x.Activo == true).AnyAsync(cancellationToken);
            if (existsRuc) return CustomValidationMessage(context, Resources.Common.DuplicateRucRecord);

            return true;
        }
    }
}
