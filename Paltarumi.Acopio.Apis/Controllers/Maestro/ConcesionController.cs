using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Maestro;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Application.Abstractions.Maestro;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/concesion")]
    public class ConcesionController: IConcesionApplication
    {
        private readonly IConcesionApplication _concesionApplication;

        public ConcesionController(IConcesionApplication concesionApplication)
            => _concesionApplication = concesionApplication;

        [HttpPost]
        public async Task<ResponseDto<GetConcesionDto>> Create(CreateConcesionDto createDto)
            => await _concesionApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetConcesionDto>> Update(UpdateConcesionDto updateDto)
            => await _concesionApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _concesionApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetConcesionDto>> Get(int id)
            => await _concesionApplication.Get(id);


        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchConcesionDto>>> Search(SearchParamsDto<ConcesionFilterDto> searchParams)
            => await _concesionApplication.Search(searchParams);
        
        [HttpGet("codigounico/{codigoUnico}")]
        public async Task<ResponseDto<GetConcesionDto>> Get(string codigoUnico)
            => await _concesionApplication.Get(codigoUnico);
    }
}
