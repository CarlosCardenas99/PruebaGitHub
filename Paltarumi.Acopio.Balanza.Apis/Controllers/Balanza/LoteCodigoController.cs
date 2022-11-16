using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Balanza
{
    //[Authorize]
    [ApiController]
    [Route("api/lotecodigo")]
    public class LoteCodigoController
    {
        private readonly ILoteCodigoApplication _lotecodigoApplication;

        public LoteCodigoController(ILoteCodigoApplication lotecodigoApplication)
            => _lotecodigoApplication = lotecodigoApplication;

        [HttpPost]
        public async Task<ResponseDto<GetLoteCodigoDto>> Create(CreateLoteCodigoDto createDto)
            => await _lotecodigoApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetLoteCodigoDto>> Update(UpdateLoteCodigoDto updateDto)
            => await _lotecodigoApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _lotecodigoApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetLoteCodigoDto>> Get(int id)
            => await _lotecodigoApplication.Get(id);

        [HttpGet("list/{loteCodigo}")]
        public async Task<ResponseDto<IEnumerable<ListLoteCodigoDto>>> List(string loteCodigo)
            => await _lotecodigoApplication.List(loteCodigo);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchLoteCodigoDto>>> Search(SearchParamsDto<SearchLoteCodigoFilterDto> searchParams)
            => await _lotecodigoApplication.Search(searchParams);
    }
}
