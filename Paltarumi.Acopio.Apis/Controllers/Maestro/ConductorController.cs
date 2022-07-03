using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/conductor")]
    public class ConductorController
    {
        private readonly IConductorApplication _conductorApplication;

        public ConductorController(IConductorApplication conductorApplication)
            => _conductorApplication = conductorApplication;

        [HttpPost]
        public async Task<ResponseDto<GetConductorDto>> Create(CreateConductorDto createDto)
            => await _conductorApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetConductorDto>> Update(UpdateConductorDto updateDto)
            => await _conductorApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _conductorApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetConductorDto>> Get(int id)
            => await _conductorApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListConductorDto>>> List()
            => await _conductorApplication.List();

        [HttpPost("findbydocument")]
        public async Task<ResponseDto<GetConductorDto>> GetByDocument(GetConductorByDocumentFilterDto filter)
            => await _conductorApplication.GetByDocument(filter);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchConductorDto>>> Search(SearchParamsDto<SearchConductorFilterDto> searchParams)
            => await _conductorApplication.Search(searchParams);
    }
}
