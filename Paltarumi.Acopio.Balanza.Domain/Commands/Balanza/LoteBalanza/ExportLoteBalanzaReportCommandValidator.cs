using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class ExportLoteBalanzaReportCommandValidator : CommandValidatorBase<ExportLoteBalanzaReportCommand>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;
        public ExportLoteBalanzaReportCommandValidator(IRepository<Entity.Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;

            RequiredField(x => x.IdTicket, Resources.Balanza.Ticket.IdTicket)
                .DependentRules(() =>
                {
                    RuleFor(x => x.IdTicket)
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

        protected async Task<bool> ValidateExistenceAsync(ExportLoteBalanzaReportCommand command, int idTicket, ValidationContext<ExportLoteBalanzaReportCommand> context, CancellationToken cancellationToken)
        {
            var exists = await _ticketRepository.FindAll().Where(x => x.IdTicket == idTicket).AnyAsync(cancellationToken);
            if (!exists) throw new Exception(Resources.Common.UpdateRecordNotFound);
            return true;
        }

        protected bool ValidateFileExistence(ExportLoteBalanzaReportCommand command, string reportPath, ValidationContext<ExportLoteBalanzaReportCommand> context)
        {
            var exists = File.Exists(reportPath);
            if (!exists) throw new Exception($"{Resources.Common.ReportFileDoesNotExist}: {reportPath}");
            return true;
        }
    }
}
