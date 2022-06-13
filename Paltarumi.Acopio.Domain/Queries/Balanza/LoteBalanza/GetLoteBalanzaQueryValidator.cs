﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.LoteBalanza
{
    public class GetLoteBalanzaQueryValidator : QueryValidatorBase<GetLoteBalanzaQuery>
    {
        private readonly IRepositoryBase<Entity.LoteBalanza> _loteBalanzaRepository;

        public GetLoteBalanzaQueryValidator(IRepositoryBase<Entity.LoteBalanza> loteBalanzaRepository)
        {
            _loteBalanzaRepository = loteBalanzaRepository;

            RequiredField(x => x.Id, Resources.Balanza.LoteBalanza.IdLoteBalanza)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GetLoteBalanzaQuery command, int id, ValidationContext<GetLoteBalanzaQuery> context, CancellationToken cancellationToken)
        {
            var exists = await _loteBalanzaRepository.FindAll().Where(x => x.IdLoteBalanza == id).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.GetRecordNotFound);
            return true;
        }
    }
}
