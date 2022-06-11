using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCheckList
{
    public class UpdateLoteCheckListCommandValidator : CommandValidatorBase<UpdateLoteCheckListCommand>
    {
        private readonly IRepositoryBase<Entity.LoteCheckList> _repositoryBase;
        public UpdateLoteCheckListCommandValidator(IRepositoryBase<Entity.LoteCheckList> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdLoteCheckList, Resources.Balanza.LoteCheckList.IdLoteCheckList)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdLoteCheckList)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Balanza.LoteCheckList.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Balanza.LoteCheckList.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateLoteCheckListCommand command, int id, ValidationContext<UpdateLoteCheckListCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLoteCheckList == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
