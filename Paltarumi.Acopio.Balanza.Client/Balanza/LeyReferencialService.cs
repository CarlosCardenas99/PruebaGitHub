using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Client.Balanza
{
    public class LeyReferencialService : BaseService
    {
        protected override string ApiController => "api/leyreferencial";

        public LeyReferencialService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetLeyReferencialDto>> Insert(CreateLeyReferencialDto createDto)
            => await Post<CreateLeyReferencialDto, GetLeyReferencialDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetLeyReferencialDto>> update(UpdateLeyReferencialDto updateDto)
            => await Put<UpdateLeyReferencialDto, GetLeyReferencialDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetLeyReferencialDto>> Get(int id)
            => await Get<GetLeyReferencialDto>($"/{id}")!;

        public async Task<ResponseDto<SearchResultDto<SearchLeyReferencialDto>>> Search(SearchParamsDto<SearchLeyReferencialFilterDto> filter)
            => await Post<SearchParamsDto<SearchLeyReferencialFilterDto>, SearchResultDto<SearchLeyReferencialDto>>("/search", filter)!;
    }
}
