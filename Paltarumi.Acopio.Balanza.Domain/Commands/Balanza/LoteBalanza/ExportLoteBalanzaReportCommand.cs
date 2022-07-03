using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class ExportLoteBalanzaReportCommand : CommandBase<byte[]>
    {
        public ExportLoteBalanzaReportCommand(string reportPath, int idTicket)
        {
            ReportPath = reportPath;
            IdTicket = idTicket;
        }

        public string ReportPath { get; set; }
        public int IdTicket { get; set; }
    }
}
