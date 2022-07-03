using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Dto.Balanza.LeyReferencial;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/leyreferencial")]
    public class LeyReferencialController
    {
        private readonly ILeyReferencialApplication _leyreferencialApplication;

        public LeyReferencialController(ILeyReferencialApplication leyreferencialApplication)
            => _leyreferencialApplication = leyreferencialApplication;

        [HttpPost]
        public async Task<ResponseDto<GetLeyReferencialDto>> Create(CreateLeyReferencialDto createDto)
            => await _leyreferencialApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetLeyReferencialDto>> Update(UpdateLeyReferencialDto updateDto)
            => await _leyreferencialApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _leyreferencialApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetLeyReferencialDto>> Get(int id)
            => await _leyreferencialApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListLeyReferencialDto>>> List()
            => await _leyreferencialApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchLeyReferencialDto>>> Search(SearchParamsDto<SearchLeyReferencialFilterDto> searchParams)
            => await _leyreferencialApplication.Search(searchParams);
    }
}
