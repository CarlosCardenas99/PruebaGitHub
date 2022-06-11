using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Recodificacion
{
    public class UpdateRecodificacionCommandValidator : CommandValidatorBase<UpdateRecodificacionCommand>
    {
        private readonly IRepositoryBase<Entity.Recodificacion> _repositoryBase;
        public UpdateRecodificacionCommandValidator(IRepositoryBase<Entity.Recodificacion> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdRecodificacion, Resources.Balanza.Recodificacion.IdRecodificacion)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdRecodificacion)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Balanza.Recodificacion.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Balanza.Recodificacion.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateRecodificacionCommand command, int id, ValidationContext<UpdateRecodificacionCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdRecodificacion == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
