using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Transporte
{
    public class CreateTransporteCommandValidator : CommandValidatorBase<CreateTransporteCommand>
    {
        private readonly IRepositoryBase<Entity.Transporte> _repositoryBase;
        public CreateTransporteCommandValidator(IRepositoryBase<Entity.Transporte> repositoryBase)
        {
            _repositoryBase = repositoryBase;
            RequiredInformation(x => x.CreateDto).DependentRules(() =>
            {
                RuleFor(x => x.CreateDto)
                    .MustAsync(ValidateExistenceAsync)
                    .WithCustomValidationMessage();
                //RequiredString(x => x.CreateDto.Codigo, Resources.Maestro.Transporte.Codigo, 5, 10);
                //RequiredField(x => x.CreateDto.FechaIngreso, Resources.Maestro.Transporte.FechaIngreso);
            });
        }
        protected async Task<bool> ValidateExistenceAsync(CreateTransporteCommand command, CreateTransporteDto createDto, ValidationContext<CreateTransporteCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.Ruc == createDto.Ruc && x.Activo == true).AnyAsync(cancellationToken);
            if (exists) return CustomValidationMessage(context, Resources.Common.DuplicateRucRecord);

            return true;
        }
    }
}
