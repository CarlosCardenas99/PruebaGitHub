using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/concesion")]
    public class ConcesionController : IConcesionApplication
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
        public async Task<ResponseDto<SearchResultDto<SearchConcesionDto>>> Search(SearchParamsDto<SearchConcesionFilterDto> searchParams)
            => await _concesionApplication.Search(searchParams);

        [HttpGet("codigounico/{codigoUnico}")]
        public async Task<ResponseDto<GetConcesionDto>> Get(string codigoUnico)
            => await _concesionApplication.Get(codigoUnico);

        [HttpPost("list")]
        public async Task<ResponseDto<IEnumerable<ListConcesionDto>>> List(ListConcesionFilterDto filter)
            => await _concesionApplication.List(filter);

        [HttpPost("select")]
        public async Task<ResponseDto<SearchResultDto<SelectConcesionDto>>> Select(SearchParamsDto<SelectConcesionFilterDto> searchParams)
            => await _concesionApplication.Select(searchParams);
    }
}
