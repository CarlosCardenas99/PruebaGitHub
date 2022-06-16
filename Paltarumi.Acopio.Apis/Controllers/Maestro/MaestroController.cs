using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/maestro")]
    public class MaestroController
    {
        private readonly IMaestroApplication _maestroApplication;

        public MaestroController(IMaestroApplication maestroApplication)
            => _maestroApplication = maestroApplication;

        [HttpPost]
        public async Task<ResponseDto<GetMaestroDto>> Create(CreateMaestroDto createDto)
            => await _maestroApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetMaestroDto>> Update(UpdateMaestroDto updateDto)
            => await _maestroApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _maestroApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetMaestroDto>> Get(int id)
            => await _maestroApplication.Get(id);

        [HttpGet("list/{codigoTabla}")]
        public async Task<ResponseDto<IEnumerable<ListMaestroDto>>> List(string codigoTabla)
            => await _maestroApplication.List(codigoTabla);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchMaestroDto>>> Search(SearchParamsDto<SearchMaestroFilterDto> searchParams)
            => await _maestroApplication.Search(searchParams);
    }
}
