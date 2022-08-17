using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class UpdateLoteCodigoCommandValidator : CommandValidatorBase<UpdateLoteCodigoCommand>
    {
        private readonly IRepository<Entity.LoteCodigo> _repositoryBase;
        public UpdateLoteCodigoCommandValidator(IRepository<Entity.LoteCodigo> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdLoteCodigo, Resources.Balanza.LoteCodigo.IdLoteCodigo)
                .DependentRules(() =>
                {
                    RuleFor(x => x.UpdateDto.IdLoteCodigo)
                        .MustAsync(ValidateExistenceAsync)
                        .Must(ValidateExistenceIdLoteAsync)
                        .WithCustomValidationMessage();
                });
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateLoteCodigoCommand command, int id, ValidationContext<UpdateLoteCodigoCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLoteCodigo == id).AnyAsync(cancellationToken);

            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);

            return true;
        }
        protected   bool ValidateExistenceIdLoteAsync(UpdateLoteCodigoCommand command, int id, ValidationContext<UpdateLoteCodigoCommand> context)
        {
            var loteCodigoTipo = command.UpdateDto.IdLoteCodigoTipo;
            var idLote = command.UpdateDto.IdLote;

            if (loteCodigoTipo != Constants.LoteCodigo.Tipo.MUESTRA_REFERENCIAL && idLote==null) return  CustomValidationMessage(context, Resources.Common.UpdateLoteCodigo);           

            return  true;
        }


    }
}
