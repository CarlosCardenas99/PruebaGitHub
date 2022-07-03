using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Apis.Controllers.Base;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Reportes;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Reporte
{
    [ApiController]
    [Route("api/guias")]
    public class GuiasController : ApiControllerBase
    {
        private readonly IGuiasApplication _guiaApplication;
        public GuiasController(IServiceProvider serviceProvider, IGuiasApplication guiaApplication) : base(serviceProvider)
           => _guiaApplication = guiaApplication;


        [HttpGet("guiarecepmineral/{id}")]
        public async Task<IActionResult> GuiaRmReport(int id)
            => await ViewFile(
                await _guiaApplication.ExportReport(GetSettingFilePath("ReportOptions:BalanzaFolder", "RecepcionMineralReport.trdp"), id),
                "GuiaRecepcionMineralReport.pdf"
            );
    }
}
