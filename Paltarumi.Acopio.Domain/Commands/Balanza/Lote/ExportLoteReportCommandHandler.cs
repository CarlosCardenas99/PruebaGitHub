using AutoMapper;
using Microsoft.Extensions.Configuration;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Extensions;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using System.Collections;
using Telerik.Reporting;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class ExportLoteReportCommandHandler : CommandHandlerBase<ExportLoteReportCommand, byte[]>
    {
        private readonly IConfiguration _configuration;

        public ExportLoteReportCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ExportLoteReportCommandValidator validator,
            IConfiguration configuration
        ) : base(unitOfWork, mapper, validator)
        {
            _configuration = configuration;
        }

        public override async Task<ResponseDto<byte[]>> HandleCommand(ExportLoteReportCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<byte[]>();

            var report = default(Report);
            var reportPackager = new ReportPackager();
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var sourceStream = File.OpenRead(request.ReportPath))
            {
                report = (Report)reportPackager.UnpackageDocument(sourceStream);
            }

            report.UpdateDataSource("LoteDataSource", connectionString, new Dictionary<string, object> {
                { "@IdLote", request.IdLote }
            });

            report.UpdateDataSource("TicketDataSource", connectionString, new Dictionary<string, object> {
                { "@IdLote", request.IdLote }
            });

            var reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            var instanceReportSource = new InstanceReportSource { ReportDocument = report };
            var result = reportProcessor.RenderReport("PDF", instanceReportSource, new Hashtable());

            if (result.HasErrors)
            {
                result.Errors.ToList().ForEach(error =>
                {
                    response.AddErrorResult(error);
                });

                return response;
            }

            response.UpdateData(result.DocumentBytes);

            return await Task.FromResult(response);
        }
    }
}
