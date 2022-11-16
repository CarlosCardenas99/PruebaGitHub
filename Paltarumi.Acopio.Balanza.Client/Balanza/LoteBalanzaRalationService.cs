using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Client.Balanza
{
    public class LoteBalanzaRalationService : BaseService
    {
        protected override string ApiController => "api/LoteBalanzaRalation";

        public LoteBalanzaRalationService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetLoteBalanzaRalationDto>> Insert(CreateLoteBalanzaRalationDto createDto)
            => await Post<CreateLoteBalanzaRalationDto, GetLoteBalanzaRalationDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetLoteBalanzaRalationDto>> Update(UpdateLoteBalanzaRalationDto updateDto)
            => await Put<UpdateLoteBalanzaRalationDto, GetLoteBalanzaRalationDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetLoteBalanzaRalationDto>> Get(int id)
            => await Get<GetLoteBalanzaRalationDto>($"/{id}")!;

        public async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaRalationDto>>> Search(SearchParamsDto<SearchLoteBalanzaRalationFilterDto> filter)
            => await Post<SearchParamsDto<SearchLoteBalanzaRalationFilterDto>, SearchResultDto<SearchLoteBalanzaRalationDto>>("/search", filter)!;

        public async Task<ResponseDto<IEnumerable<ListLoteBalanzaRalationDto>>> List()
            => await Get<IEnumerable<ListLoteBalanzaRalationDto>>($"/list")!;
    }
}
