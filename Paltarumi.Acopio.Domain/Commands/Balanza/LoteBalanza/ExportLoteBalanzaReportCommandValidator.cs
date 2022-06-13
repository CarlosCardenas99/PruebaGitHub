using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class ExportLoteBalanzaReportCommandValidator : CommandValidatorBase<ExportLoteBalanzaReportCommand>
    {
        private readonly IRepositoryBase<Entity.LoteBalanza> _repositoryBase;
        public ExportLoteBalanzaReportCommandValidator(IRepositoryBase<Entity.LoteBalanza> repositoryBase)
        {
            _repositoryBase = repositoryBase;

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

        protected async Task<bool> ValidateExistenceAsync(ExportLoteBalanzaReportCommand command, int idLoteBalanza, ValidationContext<ExportLoteBalanzaReportCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLoteBalanza == idLoteBalanza).AnyAsync(cancellationToken);
            if (!exists) throw new Exception(Resources.Common.UpdateRecordNotFound);
            return true;
        }

        protected bool ValidateFileExistence(ExportLoteBalanzaReportCommand command, string reportPath, ValidationContext<ExportLoteBalanzaReportCommand> context)
        {
            var exists = File.Exists(reportPath);
            if (!exists) throw new Exception(Resources.Common.ReportFileDoesNotExist);
            return true;
        }
    }
}
