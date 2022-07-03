using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Acopio.ItemCheck
{
    public class UpdateItemCheckCommandValidator : CommandValidatorBase<UpdateItemCheckCommand>
    {
        private readonly IRepository<Entity.ItemCheck> _repositoryBase;
        public UpdateItemCheckCommandValidator(IRepository<Entity.ItemCheck> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdItemCheck, Resources.Maestro.ItemCheck.IdItemCheck)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdItemCheck)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Maestro.ItemCheck.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Maestro.ItemCheck.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateItemCheckCommand command, int id, ValidationContext<UpdateItemCheckCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdItemCheck == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
