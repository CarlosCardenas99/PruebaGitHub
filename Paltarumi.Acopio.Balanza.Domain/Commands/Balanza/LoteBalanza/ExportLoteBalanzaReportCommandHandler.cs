using AutoMapper;
using Microsoft.Extensions.Configuration;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Extensions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using System.Collections;
using Telerik.Reporting;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class ExportLoteBalanzaReportCommandHandler : CommandHandlerBase<ExportLoteBalanzaReportCommand, byte[]>
    {
        private readonly IConfiguration _configuration;

        public ExportLoteBalanzaReportCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ExportLoteBalanzaReportCommandValidator validator,
            IConfiguration configuration
        ) : base(unitOfWork, mapper, validator)
        {
            _configuration = configuration;
        }

        public override async Task<ResponseDto<byte[]>> HandleCommand(ExportLoteBalanzaReportCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<byte[]>();

            var report = default(Report);
            var reportPackager = new ReportPackager();
            var connectionString = Environment.GetEnvironmentVariable("CN_ACOPIO_BALANZA") ?? _configuration.GetConnectionString("DefaultConnection");

            using (var sourceStream = File.OpenRead(request.ReportPath))
            {
                report = (Report)reportPackager.UnpackageDocument(sourceStream);
            }

            report.UpdateDataSource("TicketDataSource", connectionString, new Dictionary<string, object> {
                { "@Ticket_idTicket", request.IdTicket }
            });

            var reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            var instanceReportSource = new InstanceReportSource { ReportDocument = report };
            var result = reportProcessor.RenderReport("PDF", instanceReportSource, new Hashtable());

            if (result.HasErrors) throw result.Errors.First();

            response.UpdateData(result.DocumentBytes);

            return await Task.FromResult(response);
        }
    }
}
