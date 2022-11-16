﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LeyReferencial
{
    public class UpdateLeyReferencialCommandValidator : CommandValidatorBase<UpdateLeyReferencialCommand>
    {
        private readonly IRepository<Entities.LeyReferencial> _repositoryBase;
        public UpdateLeyReferencialCommandValidator(IRepository<Entities.LeyReferencial> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredInformation(x => x.UpdateDto).DependentRules(() =>
            {
                RequiredField(x => x.UpdateDto.IdLeyReferencial, Resources.Balanza.LeyReferencial.IdLeyReferencial)
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UpdateDto.IdLeyReferencial)
                            .MustAsync(ValidateExistenceAsync)
                            .WithCustomValidationMessage();
                    });
                //RequiredString(x => x.UpdateDto.Codigo, Resources.Balanza.LeyReferencial.Codigo, 5, 10);
                //RequiredField(x => x.UpdateDto.FechaIngreso, Resources.Balanza.LeyReferencial.FechaIngreso);
            });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateLeyReferencialCommand command, int id, ValidationContext<UpdateLeyReferencialCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLeyReferencial == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }
    }
}
