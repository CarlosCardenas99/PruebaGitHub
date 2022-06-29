using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Reportes
{
    public class GuiaRecepcionMineralReportCommandValidator : CommandValidatorBase<GuiaRecepcionMineralReportCommand>
    {
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        public GuiaRecepcionMineralReportCommandValidator(IRepository<Entity.LoteBalanza> loteBalanzaRepository)
        {
            _loteBalanzaRepository = loteBalanzaRepository;

            RequiredField(x => x.IdLoteBalanza, Resources.Balanza.LoteBalanza.IdLoteBalanza)
                .DependentRules(() =>
                {
                    RuleFor(x => x.IdLoteBalanza)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage()
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.ReportPath)
                                .Must(ValidateFileExistence)
                                .WithCustomValidationMessage();
                        });
                });
        }

        protected async Task<bool> ValidateExistenceAsync(GuiaRecepcionMineralReportCommand command, int idLoteBalanza, ValidationContext<GuiaRecepcionMineralReportCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _loteBalanzaRepository.FindAll().Where(x => x.IdLoteBalanza == idLoteBalanza).AnyAsync(cancellationToken);
            if (!exists) throw new Exception(Resources.Common.UpdateRecordNotFound);
            return true;
        }

        protected bool ValidateFileExistence(GuiaRecepcionMineralReportCommand command, string reportPath, ValidationContext<GuiaRecepcionMineralReportCommand> context)
        {
            var exists = File.Exists(reportPath);
            if (!exists) throw new Exception($"{Resources.Common.ReportFileDoesNotExist}: {reportPath}");
            return true;
        }
    }
}
