using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
{
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

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListLoteCodigoDto>>> List()
            => await _lotecodigoApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchLoteCodigoDto>>> Search(SearchParamsDto<SearchLoteCodigoFilterDto> searchParams)
            => await _lotecodigoApplication.Search(searchParams);
    }
}
