using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Reportes
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
