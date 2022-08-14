using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class CreateLoteCodigoCommandValidator : CommandValidatorBase<CreateLoteCodigoCommand>
    {
        private readonly IRepository<Entity.LoteCodigo> _repositoryBase;
        public CreateLoteCodigoCommandValidator(IRepository<Entity.LoteCodigo> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    //RequiredString(x => x.CreateDto.IdLoteCodigoTipo, Resources.Balanza.LoteCodigo.IdLoteCodigoTipo,2,2);
                    //RequiredField(x => x.CreateDto.IdLote, Resources.Balanza.LoteCodigo.IdLote);
                });
        }

        //protected async Task<bool> ValidateExistenceAsync(CreateLoteCodigoCommand command, int id, ValidationContext<CreateLoteCodigoCommand> context, CancellationToken cancellationToken)
        //{
        //    var exists = await _repositoryBase.FindAll().Where(x => x.IdLoteCodigo == id).AnyAsync(cancellationToken);
        //    if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
        //    return true;
        //}
    }
}
