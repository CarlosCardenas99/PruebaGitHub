using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
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


        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchMaestroDto>>> Search(SearchParamsDto<SearchMaestroFilterDto> searchParams)
            => await _maestroApplication.Search(searchParams);
    }
}
