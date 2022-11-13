using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/lotebalanzaralation")]
    public class LoteBalanzaRalationController
    {
        private readonly ILoteBalanzaRalationApplication _lotebalanzaralationApplication;

        public LoteBalanzaRalationController(ILoteBalanzaRalationApplication lotebalanzaralationApplication)
            => _lotebalanzaralationApplication = lotebalanzaralationApplication;

        [HttpPost]
        public async Task<ResponseDto<GetLoteBalanzaRalationDto>> Create(CreateLoteBalanzaRalationDto createDto)
            => await _lotebalanzaralationApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetLoteBalanzaRalationDto>> Update(UpdateLoteBalanzaRalationDto updateDto)
            => await _lotebalanzaralationApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _lotebalanzaralationApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetLoteBalanzaRalationDto>> Get(int id)
            => await _lotebalanzaralationApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListLoteBalanzaRalationDto>>> List()
            => await _lotebalanzaralationApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaRalationDto>>> Search(SearchParamsDto<SearchLoteBalanzaRalationFilterDto> searchParams)
            => await _lotebalanzaralationApplication.Search(searchParams);
    }
}
