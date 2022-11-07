using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Export.Application.Dto;

namespace Paltarumi.Acopio.Balanza.Client.Balanza
{
    public class LoteBalanzaService : BaseService
    {
        protected override string ApiController => "api/lotebalanza";

        public LoteBalanzaService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetLoteBalanzaDto>> Insert(CreateLoteBalanzaDto createDto)
            => await Post<CreateLoteBalanzaDto, GetLoteBalanzaDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetLoteBalanzaDto>> Update(UpdateLoteBalanzaDto updateDto)
            => await Put<UpdateLoteBalanzaDto, GetLoteBalanzaDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto<GetLoteBalanzaDto>> UpdateStatus(UpdateStatusLoteBalanzaDto updateDto)
            => await Put<UpdateStatusLoteBalanzaDto, GetLoteBalanzaDto>("/updatestatus", updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetLoteBalanzaDto>> Get(int id)
            => await Get<GetLoteBalanzaDto>($"/{id}")!;

        public async Task<HttpResponseMessage> Export(SearchParamsExportDto<SearchLoteBalanzaFilterDto> exportParams)
            => await PostFile("/export", exportParams)!;

        public async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>> Search(SearchParamsDto<SearchLoteBalanzaFilterDto> filter)
            => await Post<SearchParamsDto<SearchLoteBalanzaFilterDto>, SearchResultDto<SearchLoteBalanzaDto>>("/search", filter)!;
    }
}
