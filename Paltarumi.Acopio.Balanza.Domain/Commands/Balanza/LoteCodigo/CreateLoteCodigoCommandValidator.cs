using FluentValidation;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class CreateLoteCodigoCommandValidator : CommandValidatorBase<CreateLoteCodigoCommand>
    {
        private readonly IRepository<Entities.LoteCodigo> _repositoryBase;
        public CreateLoteCodigoCommandValidator(IRepository<Entities.LoteCodigo> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.CreateDto).DependentRules(() =>
                {
                    RuleFor(x => x.CreateDto)
                        .Must(ValidateExistenceIdLoteAsync)
                        .WithCustomValidationMessage();
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
