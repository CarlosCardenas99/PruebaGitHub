using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/duenomuestra")]
    public class DuenoMuestraController
    {
        private readonly IDuenoMuestraApplication _duenomuestraApplication;

        public DuenoMuestraController(IDuenoMuestraApplication duenomuestraApplication)
            => _duenomuestraApplication = duenomuestraApplication;

        [HttpPost]
        public async Task<ResponseDto<GetDuenoMuestraDto>> Create(CreateDuenoMuestraDto createDto)
            => await _duenomuestraApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetDuenoMuestraDto>> Update(UpdateDuenoMuestraDto updateDto)
            => await _duenomuestraApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _duenomuestraApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetDuenoMuestraDto>> Get(int id)
            => await _duenomuestraApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListDuenoMuestraDto>>> List()
            => await _duenomuestraApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchDuenoMuestraDto>>> Search(SearchParamsDto<SearchDuenoMuestraFilterDto> searchParams)
            => await _duenomuestraApplication.Search(searchParams);
    }
}
