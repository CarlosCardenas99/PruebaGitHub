using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class UpdateLoteOperacionCommandValidator : CommandValidatorBase<UpdateLoteOperacionCommand>
    {
        private readonly IRepository<Entities.LoteOperacion> _repositoryBase;
        public UpdateLoteOperacionCommandValidator(IRepository<Entities.LoteOperacion> repositoryBase)
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
