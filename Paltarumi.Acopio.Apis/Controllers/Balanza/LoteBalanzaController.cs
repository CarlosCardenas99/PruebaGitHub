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

        [HttpPut("updatechecklist")]
        public async Task<ResponseDto<GetLoteBalanzaCheckListDto>> UpdateLoteBalanzaCheckList(UpdateLoteBalanzaCheckListDto updateDto)
            => await _loteBalanzaApplication.UpdateLoteBalanzaCheckList(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
            => await _loteBalanzaApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetLoteBalanzaDto>> Get(int id)
            => await _loteBalanzaApplication.Get(id);

        //------------------------------------------------------------------
        [HttpGet("bycodigo/{codigo}")]
        public async Task<ResponseDto<GetLoteBalanzaCodigoDto>> GetbyCodigo(string codigo)
            => await _loteBalanzaApplication.GetbyCodigo(codigo);

        //----------------------------------------------------------

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListLoteBalanzaDto>>> List()
            => await _loteBalanzaApplication.List();

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>> Search(SearchParamsDto<SearchLoteBalanzaFilterDto> searchParams)
            => await _loteBalanzaApplication.Search(searchParams);

        [HttpPost("search/checklist")]
        public async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaChecklistDto>>> SearchWithCheckList(SearchParamsDto<SearchLoteBalanzaChecklistFilterDto> searchParams)
            => await _loteBalanzaApplication.SearchWithCheckList(searchParams);

        [HttpGet("download-report/{id}")]
        public async Task<FileResult> ExportReport(int id)
            => await DownloadFile(
                await _loteBalanzaApplication.ExportReport(GetSettingFilePath("ReportOptions:BalanzaFolder", "LoteReport.trdp"), id),
                "LoteReport.pdf"
            );

        [HttpGet("view-report/{id}")]
        public async Task<IActionResult> ViewReport(int id)
            => await ViewFile(
                await _loteBalanzaApplication.ExportReport(GetSettingFilePath("ReportOptions:BalanzaFolder", "LoteReport.trdp"), id),
                "LoteReport.pdf"
            );
    }
}
