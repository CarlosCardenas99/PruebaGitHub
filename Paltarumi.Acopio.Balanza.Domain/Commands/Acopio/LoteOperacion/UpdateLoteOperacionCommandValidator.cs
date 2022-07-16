using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class UpdateLoteOperacionCommandValidator : CommandValidatorBase<UpdateLoteOperacionCommand>
    {
        private readonly IRepository<Entity.LoteOperacion> _repositoryBase;
        public UpdateLoteOperacionCommandValidator(IRepository<Entity.LoteOperacion> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdLoteOperacion, Resources.Acopio.LoteOperacion.IdLoteOperacion)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdLoteOperacion)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Acopio.LoteOperacion.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Acopio.LoteOperacion.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateLoteOperacionCommand command, int id, ValidationContext<UpdateLoteOperacionCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLoteOperacion == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
