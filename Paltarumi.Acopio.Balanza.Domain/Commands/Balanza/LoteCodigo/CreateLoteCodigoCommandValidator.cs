using FluentValidation;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Constantes;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class CreateLoteCodigoCommandValidator : CommandValidatorBase<CreateLoteCodigoCommand>
    {
        private readonly IRepository<Entity.LoteCodigo> _repositoryBase;
        public CreateLoteCodigoCommandValidator(IRepository<Entity.LoteCodigo> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.CreateDto).DependentRules(() =>
                {
                    RuleFor(x => x.CreateDto)
                        .Must(ValidateExistenceIdLoteAsync)
                        .WithCustomValidationMessage();
                    //RequiredString(x => x.CreateDto.IdLoteCodigoTipo, Resources.Balanza.LoteCodigo.IdLoteCodigoTipo,2,2);
                    //RequiredField(x => x.CreateDto.IdLote, Resources.Balanza.LoteCodigo.IdLote);
                });
        }

        protected bool ValidateExistenceIdLoteAsync(CreateLoteCodigoCommand request, CreateLoteCodigoDto createDto, ValidationContext<CreateLoteCodigoCommand> context)
        {
            var loteCodigoTipo = request.CreateDto.IdLoteCodigoTipo;
            var idLote = request.CreateDto.IdLote;

            if (loteCodigoTipo != CONST_ACOPIO.LOTECODIGO_TIPO.MUESTRA_REFERENCIAL && idLote == null) return CustomValidationMessage(context, Resources.Common.UpdateLoteCodigo);

            return true;
        }
    }
}
