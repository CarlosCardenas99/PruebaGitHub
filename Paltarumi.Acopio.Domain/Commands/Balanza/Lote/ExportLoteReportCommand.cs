using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class ExportLoteReportCommand : CommandBase<byte[]>
    {
        public ExportLoteReportCommand(string reportPath, int idLote)
        {
            ReportPath = reportPath;
            IdLote = idLote;
        }

        public string ReportPath { get; set; }
        public int IdLote { get; set; }
    }
}
