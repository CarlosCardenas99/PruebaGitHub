using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Apis.Controllers.Base;
using Paltarumi.Acopio.Application.Abstractions.Balanza;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
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
