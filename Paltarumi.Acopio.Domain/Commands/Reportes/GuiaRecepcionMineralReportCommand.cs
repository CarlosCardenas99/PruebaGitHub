using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class GuiaRecepcionMineralReportCommand : CommandBase<byte[]>
    {
        public GuiaRecepcionMineralReportCommand(string reportPath, int idLoteBalanza)
        {
            ReportPath = reportPath;
            IdLoteBalanza = idLoteBalanza;
        }

        public string ReportPath { get; set; }
        public int IdLoteBalanza { get; set; }
    }
}
