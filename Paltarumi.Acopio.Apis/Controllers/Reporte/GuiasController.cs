using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Apis.Controllers.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Security.User;
using Paltarumi.Acopio.Application.Abstractions.Reportes;

namespace Paltarumi.Acopio.Apis.Controllers.Reporte
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
