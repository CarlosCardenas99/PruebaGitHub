using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/lote")]
    public class LoteController
    {
        private readonly ILoteApplication _loteApplication;

        public LoteController(ILoteApplication loteApplication)
            => _loteApplication = loteApplication;

        [HttpPost]
        public async Task<ResponseDto<GetLoteDto>> Create(CreateLoteDto createDto)
            => await _loteApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetLoteDto>> Update(UpdateLoteDto updateDto)
            => await _loteApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _loteApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetLoteDto>> Get(int id)
            => await _loteApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListLoteDto>>> List()
            => await _loteApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<ListLoteDto>>> Search(SearchParamsDto<LoteFilterDto> searchParams)
            => await _loteApplication.Search(searchParams);
    }
}
