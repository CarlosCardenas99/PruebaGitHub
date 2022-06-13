using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Apis.Controllers.Base;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Balanza
{
    [ApiController]
    [Route("api/lotebalanza")]
    public class LoteBalanzaController : ApiControllerBase
    {
        private readonly ILoteBalanzaApplication _loteBalanzaApplication;

        public LoteBalanzaController(IServiceProvider serviceProvider, ILoteBalanzaApplication loteBalanzaApplication) : base(serviceProvider)
            => _loteBalanzaApplication = loteBalanzaApplication;

        [HttpPost]
        public async Task<ResponseDto<GetLoteBalanzaDto>> Create(CreateLoteBalanzaDto createDto)
            => await _loteBalanzaApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetLoteBalanzaDto>> Update(UpdateLoteBalanzaDto updateDto)
            => await _loteBalanzaApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _loteBalanzaApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetLoteBalanzaDto>> Get(int id)
            => await _loteBalanzaApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListLoteBalanzaDto>>> List()
            => await _loteBalanzaApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>> Search(SearchParamsDto<SearchLoteBalanzaFilterDto> searchParams)
            => await _loteBalanzaApplication.Search(searchParams);

        [HttpGet("report/{id}")]
        public async Task<FileResult> ExportReport(int id)
            => await DownloadFile(
                await _loteBalanzaApplication.ExportReport(GetSettingFilePath("ReportOptions:BalanzaFolder", "LoteReport.trdp"), id),
                "LoteReport.pdf"
            );
    }
}
