using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Acopio;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCodigoTipo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Acopio
{
    [ApiController]
    [Route("api/lotecodigotipo")]
    public class LoteCodigoTipoController
    {
        private readonly ILoteCodigoTipoApplication _lotecodigotipoApplication;

        public LoteCodigoTipoController(ILoteCodigoTipoApplication lotecodigotipoApplication)
            => _lotecodigotipoApplication = lotecodigotipoApplication;


        [HttpGet("selectcombo")]
        public async Task<ResponseDto<IEnumerable<SelectComboLoteCodigoTipoDto>>> SelectCombo()
            => await _lotecodigotipoApplication.SelectCombo();

    }
}
