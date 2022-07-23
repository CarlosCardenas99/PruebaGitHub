using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Config;
using Paltarumi.Acopio.Balanza.Dto.Config.Empresa;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Config
{
    [ApiController]
    [Route("api/empresa")]
    public class EmpresaController
    {
        private readonly IEmpresaApplication _empresaApplication;

        public EmpresaController(IEmpresaApplication empresaApplication)
            => _empresaApplication = empresaApplication;


        [HttpGet("selectcombo")]
        public async Task<ResponseDto<IEnumerable<SelectComboEmpresaDto>>> SelectCombo()
            => await _empresaApplication.SelectCombo();

    }
}
