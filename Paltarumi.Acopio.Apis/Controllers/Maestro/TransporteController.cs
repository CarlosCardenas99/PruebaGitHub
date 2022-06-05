using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/transporte")]
    public class TransporteController
    {
        private readonly ITransporteApplication _transporteApplication;

        public TransporteController(ITransporteApplication transporteApplication)
            => _transporteApplication = transporteApplication;

        [HttpPost]
        public async Task<ResponseDto<GetTransporteDto>> Create(CreateTransporteDto createDto)
            => await _transporteApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetTransporteDto>> Update(UpdateTransporteDto updateDto)
            => await _transporteApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _transporteApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetTransporteDto>> Get(int id)
            => await _transporteApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListTransporteDto>>> List()
            => await _transporteApplication.List();

        [HttpGet("ruc/{ruc}")]
        public async Task<ResponseDto<GetTransporteDto>> Get(string ruc)
            => await _transporteApplication.Get(ruc);


        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchTransporteDto>>> Search(SearchParamsDto<TransporteFilterDto> searchParams)
            => await _transporteApplication.Search(searchParams);
    }
}
