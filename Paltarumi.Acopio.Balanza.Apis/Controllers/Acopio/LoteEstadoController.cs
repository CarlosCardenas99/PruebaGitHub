using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Acopio;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteEstado;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Acopio
{
    [ApiController]
    [Route("api/loteestado")]
    public class LoteEstadoController
    {
        private readonly ILoteEstadoApplication _loteestadoApplication;

        public LoteEstadoController(ILoteEstadoApplication loteestadoApplication)
            => _loteestadoApplication = loteestadoApplication;

        [HttpGet("selectcombo")]
        public async Task<ResponseDto<IEnumerable<SelectComboLoteEstadoDto>>> SelectCombo()
            => await _loteestadoApplication.SelectCombo();

        //[HttpGet("{id}")]
        //public async Task<ResponseDto<GetLoteEstadoDto>> Get(int id)
        //    => await _loteestadoApplication.Get(id);

        //[HttpGet("list")]
        //public async Task<ResponseDto<IEnumerable<ListLoteEstadoDto>>> List()
        //    => await _loteestadoApplication.List();

    }
}
