using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class UpdateLoteCommandValidator : CommandValidatorBase<UpdateLoteCommand>
    {
        private readonly IRepositoryBase<Entity.Lote> _repositoryBase;
        public UpdateLoteCommandValidator(IRepositoryBase<Entity.Lote> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdLote, Resources.Balanza.Lote.IdLote)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdLote)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                RequiredString(x => x.UpdateDto.Codigo, Resources.Balanza.Lote.Codigo, 4, 10);

                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Balanza.Lote.FechaIngreso);
                //RequiredField(x => x.UpdateDto.HoraIngreso, Resources.Balanza.Lote.HoraIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateLoteCommand command, int id, ValidationContext<UpdateLoteCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLote == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
