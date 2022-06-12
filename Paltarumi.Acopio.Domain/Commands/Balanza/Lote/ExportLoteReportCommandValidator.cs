using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class ExportLoteReportCommandValidator : CommandValidatorBase<ExportLoteReportCommand>
    {
        private readonly IRepositoryBase<Entity.Lote> _repositoryBase;
        public ExportLoteReportCommandValidator(IRepositoryBase<Entity.Lote> repositoryBase)
        {
            _repositoryBase = repositoryBase;

            RequiredField(x => x.IdLote, Resources.Balanza.Lote.IdLote)
                .DependentRules(() =>
                {
                    RuleFor(x => x.IdLote)
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

        protected async Task<bool> ValidateExistenceAsync(ExportLoteReportCommand command, int idLote, ValidationContext<ExportLoteReportCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _repositoryBase.FindAll().Where(x => x.IdLote == idLote).AnyAsync(cancellationToken);
            if (!exists) return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);
            return true;
        }

        protected bool ValidateFileExistence(ExportLoteReportCommand command, string reportPath, ValidationContext<ExportLoteReportCommand> context)
        {
            var exists = File.Exists(reportPath);
            if (!exists) return CustomValidationMessage(context, Resources.Common.ReportFileDoesNotExist);
            return true;
        }
    }
}
