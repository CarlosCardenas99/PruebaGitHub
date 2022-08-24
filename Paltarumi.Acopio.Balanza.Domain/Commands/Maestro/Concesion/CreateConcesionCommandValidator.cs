using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Concesion
{
    public class CreateConcesionCommandValidator : CommandValidatorBase<CreateConcesionCommand>
    {
        private readonly IRepository<Entity.Concesion> _repositoryBase;
        public CreateConcesionCommandValidator(IRepository<Entity.Concesion> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.CreateDto)
                .DependentRules(() =>
                {
                    RuleFor(x => x.CreateDto)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                    //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.Concesion.Codigo, 5, 10);
                    //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.Concesion.FechaIngreso);
                });
        }

        protected async Task<bool> ValidateExistenceAsync(CreateConcesionCommand command, CreateConcesionDto createDto, ValidationContext<CreateConcesionCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.CodigoUnico == createDto.CodigoUnico && x.Activo == true).AnyAsync(cancellationToken);
            if (exists) return CustomValidationMessage(context, Resources.Common.DuplicateCodigoUnicoConcesionRecord);

            return true;
        }
    }
}
