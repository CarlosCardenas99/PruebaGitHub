using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Maestro
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

        [HttpPost("findbydocument")]
        public async Task<ResponseDto<GetDuenoMuestraDto>> GetByDocument(GetDuenoMuestraByDocumentFilterDto filter)
            => await _duenomuestraApplication.GetByDocument(filter);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchDuenoMuestraDto>>> Search(SearchParamsDto<SearchDuenoMuestraFilterDto> searchParams)
            => await _duenomuestraApplication.Search(searchParams);
    }
}
