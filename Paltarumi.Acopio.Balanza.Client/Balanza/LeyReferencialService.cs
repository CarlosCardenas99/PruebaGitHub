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

        public Response get(int id)
        {
            var response = EntityGet<ResponseDto<GetLeyReferencialDto>>($"/{id}");
            return ResponseNoData(response);
        }

        public Response listarLeyReferencial(SearchParamsDto<SearchLeyReferencialFilterDto> filter)
        {
            var response = EntityPost<SearchParamsDto<SearchLeyReferencialFilterDto>, ResponseDto<SearchResultDto<SearchLeyReferencialDto>>>("/search", filter);
            return ResponseSearchResult(response);
        }

        public Response insert(CreateLeyReferencialDto createDto)
        {
            var response = EntityPost<CreateLeyReferencialDto, ResponseDto<GetLeyReferencialDto>>(string.Empty, createDto);
            return ResponseData(response);
        }

        public Response update(UpdateLeyReferencialDto updateDto)
        {
            var response = EntityPut<UpdateLeyReferencialDto, ResponseDto<GetLeyReferencialDto>>(string.Empty, updateDto);
            return ResponseData(response);
        }

        public Response delete(int id)
        {
            var response = EntityDelete<ResponseDto>($"/{id}");
            return ResponseNoData(response);
        }
    }
}
