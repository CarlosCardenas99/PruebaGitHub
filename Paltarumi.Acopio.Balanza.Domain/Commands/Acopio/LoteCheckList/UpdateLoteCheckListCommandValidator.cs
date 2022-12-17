using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteCheckList
{
    public class UpdateLoteCheckListCommandValidator : CommandValidatorBase<UpdateLoteCheckListCommand>
    {
        private readonly IRepository<Entity.LoteCheckList> _repositoryBase;
        public UpdateLoteCheckListCommandValidator(IRepository<Entity.LoteCheckList> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdLoteCheckList, Resources.Acopio.LoteCheckList.IdLoteCheckList)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdLoteCheckList)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Acopio.LoteCheckList.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Acopio.LoteCheckList.FechaIngreso);
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
