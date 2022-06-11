using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyesReferenciales
{
    public class UpdateLeyesReferencialesCommandValidator : CommandValidatorBase<UpdateLeyesReferencialesCommand>
    {
        private readonly IRepositoryBase<Entity.LeyesReferenciales> _repositoryBase;
        public UpdateLeyesReferencialesCommandValidator(IRepositoryBase<Entity.LeyesReferenciales> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdLeyesReferenciales, Resources.Balanza.LeyesReferenciales.IdLeyesReferenciales)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdLeyesReferenciales)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Balanza.LeyesReferenciales.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Balanza.LeyesReferenciales.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateLeyesReferencialesCommand command, int id, ValidationContext<UpdateLeyesReferencialesCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLeyesReferenciales == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
